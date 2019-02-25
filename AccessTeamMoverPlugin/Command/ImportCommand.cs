using AccessTeamTemplateMoverPlugin.Interface;
using AccessTeamTemplateMoverPlugin.Utility;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace AccessTeamTemplateMoverPlugin.Command
{
    public class ImportCommand : ICommand
    {
        public IOrganizationService Service { get; set; }
        public string FileName { get; set; }
        public bool IsZipFile { get; set; }
        public ILogWriter LogWriter { get; set; }
        public string OrganisationUrl { get; set; }

        Dictionary<string, int> typeCodeList;

        public void Execute()
        {
            int errorCount = 0,  updatedCount = 0, createdCount = 0;

            if (IsZipFile) decompress();

            MetadataHelper metadataHelper = new MetadataHelper(Service);

            LogWriter.LogInfo("ImportCommand: Retrieving entity metadata");
            typeCodeList = metadataHelper.RetrieveEntityList();

            EntityCollectionSerializer ecSerializer = new EntityCollectionSerializer();

            LogWriter.LogInfo("ImportCommand: Deserializing file");
            EntityCollection entities = ecSerializer.Deserialize(FileName);

            LogWriter.LogInfo($"ImportCommand: Importing access team templates to {OrganisationUrl}");
            Parallel.ForEach(entities.Entities, entity =>
                {
                    var entityName = entity["entityname"].ToString();
                    if (typeCodeList.ContainsKey(entityName))
                    {
                        entity["objecttypecode"] = typeCodeList[entity["entityname"].ToString()];
                        entity.Attributes.Remove("entityname");
                        try
                        {
                            try
                            {
                                Service.Update(entity);
                                updatedCount++;
                                LogWriter.LogInfo($"ImportCommand: Updated access team template with id {entity.Id}");
                            }
                            catch (FaultException<OrganizationServiceFault>)
                            {
                                Service.Create(entity);
                                createdCount++;
                                LogWriter.LogInfo($"ImportCommand: Created access team template with id {entity.Id}");
                            }
                        }
                        catch (FaultException<OrganizationServiceFault> fe)
                        {
                            errorCount++;
                            LogWriter.LogError($"ImportCommand: An error with id {entity.Id} - {entity["teamtemplatename"]}. Details: {fe.Message}");
                        }
                    }
                }
            );

            LogWriter.LogInfo($"ImportCommand: Summary");
            LogWriter.LogInfo($"ImportCommand: Total {entities.Entities.Count}, Updated {updatedCount}, Created {createdCount}, Error {errorCount}");
        }

        void decompress()
        {
            FileName = FileZipper.Decompress(FileName);
        }

        public ImportCommand()
        {
            
        }
    }
}