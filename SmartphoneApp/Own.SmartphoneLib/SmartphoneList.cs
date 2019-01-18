using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Own.SmartphoneLib
{
    [Serializable()]
    public class SmartphoneList : List<Smartphone>, ISerializable
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
            BinaryFormatter binFormatter = new BinaryFormatter();
            FileStream fStream = new FileStream(@path, FileMode.Open);
            SmartphoneList deserialized = null;

            deserialized = (SmartphoneList)binFormatter.Deserialize(fStream);
            fStream.Close();

            this.Clear();
            this.AddRange(deserialized);
        }

        public Smartphone GetByInternalId(int internalId)
        {
            Smartphone sp = null;

            foreach (Smartphone listSp in this)
            {
                if (listSp.InternalId == internalId)
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

            if (spList.Any())
            {
                return spList;
            } else
            {
                return null;
            }
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
