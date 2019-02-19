using AccessTeamMoverPlugin.Utility;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace AccessTeamMoverPlugin.Command
{
    public class ImportCommand : ICommand
    {
        public IOrganizationService Service { get; set; }

        public string FileName { get; set; }

        public bool IsZipFile { get; set; }
        
        Dictionary<string, int> typeCodeList;

        public void Execute()
        {
            if (IsZipFile) decompress();

            MetadataHelper metadataHelper = new MetadataHelper(Service);

            Console.WriteLine("Retrieving entity list...");
            typeCodeList = metadataHelper.RetrieveEntityList();

            EntityCollectionSerializer ecSerializer = new EntityCollectionSerializer();

            Console.WriteLine("Deserializing file...");
            EntityCollection entities = ecSerializer.Deserialize(FileName);

            Console.WriteLine("Importing data...");
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
                            }
                            catch (FaultException<OrganizationServiceFault>)
                            {
                                Service.Create(entity);
                            }
                        }
                        catch (FaultException<OrganizationServiceFault> fe)
                        {
                            Console.WriteLine("Error: {0} - {1}", entity.Id, entity["teamtemplatename"]);
                            Console.WriteLine(fe.Message);
                        }
                    }
                }
            );
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
