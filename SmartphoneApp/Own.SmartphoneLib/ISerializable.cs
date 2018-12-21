using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Own.SmartphoneLib
{
    interface ISerializable
    {
        void Serialize(string path);
        void Deserialize(string path);
    }
}
