using CsvHelper;
using System.IO;

namespace Own.SmartphoneLib
{
    public class CSVSerializer : ISerializable
    {
        public void Serialize(string path, SmartphoneList spList)
        {
            using (StreamWriter streamW = new StreamWriter(@path))
            using (CsvWriter serializer = new CsvWriter(streamW))
            {
                serializer.WriteRecords(spList);
            }
        }

        public SmartphoneList Deserialize(string path)
        {
            SmartphoneList deserialized = new SmartphoneList();
            using (StreamReader streamR = new StreamReader(@path))
            using (CsvReader serializer = new CsvReader(streamR))
            {
                foreach (Smartphone listSp in serializer.GetRecords<Smartphone>()) {
                    deserialized.Add(listSp);
                }

                return deserialized;
            }
        }
    }
}
