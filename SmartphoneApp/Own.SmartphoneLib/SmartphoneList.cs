using System;
using System.Collections.Generic;

namespace Own.SmartphoneLib
{
    [Serializable()]
    public class SmartphoneList : List<Smartphone>
    {
        public void Serialize(ISerializable serializer, string path)
        {
            serializer.Serialize(path, this);
        }

        public void Deserialize(ISerializable serializer, string path)
        {
            SmartphoneList deserialized = serializer.Deserialize(path);

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
