using System.IO;
using System.Xml.Serialization;

namespace Own.SmartphoneLib
{
    public class XMLSerializer : ISerializable
    {
        public void Serialize(string path, SmartphoneList spList)
        {
            FileStream streamW = new FileStream(@path, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(SmartphoneList));

            serializer.Serialize(streamW, spList);
            streamW.Close();
        }

        public SmartphoneList Deserialize(string path)
        {
            FileStream streamR = new FileStream(@path, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(SmartphoneList));

            SmartphoneList deserialized = (SmartphoneList)serializer.Deserialize(streamR);
            streamR.Close();

            return deserialized;
        }
    }
}
