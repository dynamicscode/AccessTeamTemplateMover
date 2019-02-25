using Microsoft.Xrm.Sdk;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace AccessTeamTemplateMoverPlugin.Utility
{
    public class EntityCollectionSerializer
    {
        private string fileName;
        private readonly Encoding encoder;

        private void initializer()
        {
            fileName = "serialized_data.xml";
        }

        public EntityCollectionSerializer()
        {
            initializer();
            encoder = Encoding.UTF8;
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        public void Serialize(EntityCollection entities)
        {
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoder))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(EntityCollection));
                ser.WriteObject(writer, entities);
            }
        }

        public EntityCollection Deserialize(string filePath)
        {
            EntityCollection deserializedObject;

            FileStream fs = new FileStream(filePath, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(EntityCollection));

            deserializedObject = ser.ReadObject(reader) as EntityCollection;

            reader.Close();

            return deserializedObject;
        }
    }
}