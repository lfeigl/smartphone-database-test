﻿using System;
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
        public void Serialize()
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            FileStream fStream = new FileStream(@"added_smartphones.bin", FileMode.Create);

            binFormatter.Serialize(fStream, this);
            fStream.Close();
        }

        public void Deserialize()
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            FileStream fStream = new FileStream(@"added_smartphones.bin", FileMode.Open);
            SmartphoneList deserialized = null;

            deserialized = (SmartphoneList)binFormatter.Deserialize(fStream);
            fStream.Close();

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
