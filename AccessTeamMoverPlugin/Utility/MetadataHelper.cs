using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccessTeamTemplateMoverPlugin.Utility
{
    public class MetadataHelper
    {
        IOrganizationService service;

        public MetadataHelper(IOrganizationService organizationService)
        {
            service = organizationService;
        }

        public Dictionary<string, int> RetrieveEntityList()
        {
            RetrieveAllEntitiesRequest allSourceEntitiesReq = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.Entity
            };

            return ((RetrieveAllEntitiesResponse)service.Execute(allSourceEntitiesReq)).EntityMetadata.ToDictionary(n=> n.LogicalName, v => v.ObjectTypeCode.Value);
        }

        public RetrieveEntityResponse RetrieveEntity(string entityName)
        {
            Console.WriteLine("Retrieving entity...");
            RetrieveEntityRequest entityreq = new RetrieveEntityRequest
            {
                LogicalName = entityName,
                EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Attributes
            };

            return (RetrieveEntityResponse)service.Execute(entityreq);            
        }
    }
}
