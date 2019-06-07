using Newtonsoft.Json;
using System.IO;

namespace Own.SmartphoneLib
{
    public class JSONSerializer : ISerializable
    {
        public void Serialize(string path, SmartphoneList spList)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter streamW = new StreamWriter(@path))
            using (JsonWriter writer = new JsonTextWriter(streamW))
            {
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, spList);
            }
        }

        public SmartphoneList Deserialize(string path)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader streamR = new StreamReader(@path))
            using (JsonReader reader = new JsonTextReader(streamR))
            {
                return serializer.Deserialize<SmartphoneList>(reader);
            }
        }
    }
}
