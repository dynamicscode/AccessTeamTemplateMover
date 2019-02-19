using AccessTeamMoverPlugin.Utility;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AccessTeamMoverPlugin.Command
{
    public class ExportCommand : ICommand
    {
        public string FileName { get; set; }

        public bool IsZipFile { get; set; }
        public IOrganizationService Service { get; set; }

        readonly string entityName;
        Dictionary<string, int> typeCodeList;

        public void Execute()
        {   
            MetadataHelper metadataHelper = new MetadataHelper(Service);

            Console.WriteLine("Retrieving entity list...");
            typeCodeList = metadataHelper.RetrieveEntityList();

            FetchXmlHelper fetchXmlHelper = new FetchXmlHelper();

            Console.WriteLine("Buidling Fetch XML...");
            string fetchXml = fetchXmlHelper.Build(entityName, metadataHelper.RetrieveEntity(entityName).EntityMetadata.Attributes);

            Console.WriteLine("Retrieving data...");
            EntityCollection entities = Service.RetrieveMultiple(new FetchExpression(fetchXml));

            Console.WriteLine("Inserting entity name...");
            Parallel.ForEach(entities.Entities, entity =>
            //foreach(Entity entity in entities.Entities)
            {
                entity["entityname"] = getEntityName(entity);
            }
            );

            EntityCollectionSerializer ecSerializer = new EntityCollectionSerializer()
            {
                FileName = FileName,
            };

            Console.WriteLine("Serializing data...");
            ecSerializer.Serialize(entities);

            compressFile();
        }

        private void compressFile()
        {
            if (IsZipFile)
            {
                Console.WriteLine("Compressing the file...");
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
