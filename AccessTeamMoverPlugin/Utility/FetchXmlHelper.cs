using Microsoft.Xrm.Sdk.Metadata;
using System.Linq;
using System.Text;

namespace DynamicsCode.AccessTeamTemplateMoverPlugin.Utility
{
    internal class FetchXmlHelper
    {
        
        string[] ignoredAttributes;

        public FetchXmlHelper()
        {
            ignoredAttributes = new string[] { "issystem", "supportingsolutionid" };
        }

        public string Build(string entityName, AttributeMetadata[] attributeMetadata)
        {
            StringBuilder fetchXml = new StringBuilder();

            fetchXml.Append("<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>");
            fetchXml.AppendFormat("<entity name='{0}'>", entityName);

            foreach (AttributeMetadata amd in attributeMetadata)
            {
                if (!ignoredAttributes.Contains(amd.LogicalName))
                {
                    fetchXml.AppendFormat("<attribute name='{0}' />", amd.LogicalName);
                }
            }

            fetchXml.Append("</entity></fetch>");

            return fetchXml.ToString();
        }
    }
}
