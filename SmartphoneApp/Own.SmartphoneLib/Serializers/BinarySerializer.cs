using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Own.SmartphoneLib
{
    public class BinarySerializer : ISerializable
    {
        public void Serialize(string path, SmartphoneList spList)
        {
            FileStream streamW = new FileStream(@path, FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();

            serializer.Serialize(streamW, spList);
            streamW.Close();
        }

        public SmartphoneList Deserialize(string path)
        {
            FileStream streamR = new FileStream(@path, FileMode.Open);
            BinaryFormatter serializer = new BinaryFormatter();

            SmartphoneList deserialized = (SmartphoneList)serializer.Deserialize(streamR);
            streamR.Close();

            return deserialized;
        }
    }
}
