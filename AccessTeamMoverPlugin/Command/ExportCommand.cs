using AccessTeamTemplateMoverPlugin.Interface;
using AccessTeamTemplateMoverPlugin.Utility;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AccessTeamTemplateMoverPlugin.Command
{
    public class ExportCommand : ICommand
    {
        public string FileName { get; set; }
        public bool IsZipFile { get; set; }
        public IOrganizationService Service { get; set; }
        public ILogWriter LogWriter { get; set; }
        public string OrganisationUrl { get; set; }

        readonly string entityName;
        Dictionary<string, int> typeCodeList;

        public void Execute()
        {   
            MetadataHelper metadataHelper = new MetadataHelper(Service);

            LogWriter.LogInfo("ExportCommand: Retrieving entity list");
            typeCodeList = metadataHelper.RetrieveEntityList();

            FetchXmlHelper fetchXmlHelper = new FetchXmlHelper();

            LogWriter.LogInfo("ExportCommand: Buidling Fetch XML");
            string fetchXml = fetchXmlHelper.Build(entityName, metadataHelper.RetrieveEntity(entityName).EntityMetadata.Attributes);
            LogWriter.LogInfo(fetchXml);

            LogWriter.LogInfo($"ExportCommand: Exporting data from {OrganisationUrl}");
            EntityCollection entities = Service.RetrieveMultiple(new FetchExpression(fetchXml));
            LogWriter.LogInfo($"ExportCommand: Retrieved data, Count: {entities.Entities.Count}");

            Parallel.ForEach(entities.Entities, entity =>
                {
                    entity["entityname"] = getEntityName(entity);
                }
            );

            EntityCollectionSerializer ecSerializer = new EntityCollectionSerializer()
            {
                FileName = FileName,
            };

            LogWriter.LogInfo("ExportCommand: Serializing data");
            ecSerializer.Serialize(entities);

            compressFile();
        }

        private void compressFile()
        {
            if (IsZipFile)
            {
                LogWriter.LogInfo("ExportCommand: Compressing the file");
                FileZipper.Compress(new FileInfo(FileName));
            }
        }

        private string getEntityName(Entity entity)
        {
            return (from s in typeCodeList where s.Value == int.Parse(entity["objecttypecode"].ToString()) select s.Key).FirstOrDefault();
        }

        public ExportCommand()
        {
            typeCodeList = new Dictionary<string, int>();
            entityName = "teamtemplate";
        }
    }
}
