using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Own.SmartphoneLib
{
    [Serializable()]
    public class SmartphoneList : List<Smartphone>
    {
        public void Serialize(string path)
        {
            string ext = Path.GetExtension(path);

            if (ext.Equals(".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter streamW = new StreamWriter(@path))
                using (JsonWriter writer = new JsonTextWriter(streamW))
                {
                    writer.Formatting = Formatting.Indented;
                    serializer.Serialize(writer, this);
                }
            }
            else if (ext.Equals(".xml"))
            {
                FileStream streamW = new FileStream(@path, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(SmartphoneList));

                serializer.Serialize(streamW, this);
                streamW.Close();
            }
            else if (ext.Equals(".csv"))
            {
                using (StreamWriter streamW = new StreamWriter(@path))
                using (CsvWriter serializer = new CsvWriter(streamW))
                {
                    serializer.WriteRecords(this);
                }
            }
            else if (ext.Equals(".bin"))
            {
                FileStream streamW = new FileStream(@path, FileMode.Create);
                BinaryFormatter serializer = new BinaryFormatter();

                serializer.Serialize(streamW, this);
                streamW.Close();
            }
        }

        public void Deserialize(string path)
        {
            string ext = Path.GetExtension(path);
            SmartphoneList deserialized = new SmartphoneList();

            if (ext.Equals(".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader streamR = new StreamReader(@path))
                using (JsonReader reader = new JsonTextReader(streamR))
                {
                    deserialized = serializer.Deserialize<SmartphoneList>(reader);
                }
            }
            else if (ext.Equals(".xml"))
            {
                FileStream streamR = new FileStream(@path, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(SmartphoneList));

                deserialized = (SmartphoneList)serializer.Deserialize(streamR);
                streamR.Close();
            }
            else if (ext.Equals(".csv"))
            {
                using (StreamReader streamR = new StreamReader(@path))
                using (CsvReader serializer = new CsvReader(streamR))
                {
                    List<Smartphone> smartphones = serializer.GetRecords<Smartphone>().ToList();
                    deserialized.AddRange(smartphones);
                }
            }
            else if (ext.Equals(".bin"))
            {
                FileStream streamR = new FileStream(@path, FileMode.Open);
                BinaryFormatter serializer = new BinaryFormatter();

                deserialized = (SmartphoneList)serializer.Deserialize(streamR);
                streamR.Close();
            }

            this.Clear();
            this.AddRange(deserialized);
        }

        public Smartphone GetByInternalId(int internalId)
        {
            Smartphone sp = null;

            foreach (Smartphone listSp in this)
            {
                if (listSp.InternalId.Equals(internalId))
                {
                    sp = listSp;
                    break;
                }
            }

            return sp;
        }

        public SmartphoneList GetByManufacturer(string manufacturer)
        {
            SmartphoneList spList = new SmartphoneList();

            foreach (Smartphone listSp in this)
            {
                if (listSp.Manufacturer.Equals(manufacturer))
                {
                    spList.Add(listSp);
                }
            }

            return spList;
        }

        public Smartphone GetCheapest()
        {
            Smartphone sp = this[0];

            foreach (Smartphone listSp in this)
            {
                if (listSp.Price < sp.Price)
                {
                    sp = listSp;
                }
            }

            return sp;
        }

        public void SetDiscount(int percentage)
        {
            double discount = (double)percentage / 100;

            foreach (Smartphone listSp in this)
            {
                listSp.Price -= Math.Round(listSp.Price * discount, 2);
            }
        }
    }
}
