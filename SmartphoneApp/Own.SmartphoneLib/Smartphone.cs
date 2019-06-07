using System;

namespace Own.SmartphoneLib
{
    [Serializable()]
    public class Smartphone : DomainObject
    {
        public int InternalId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
    }
}
