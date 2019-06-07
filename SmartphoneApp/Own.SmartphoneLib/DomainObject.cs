using System;

namespace Own.SmartphoneLib
{
    [Serializable()]
    public abstract class DomainObject
    {
        public Guid Id { get; set; }

        public DomainObject()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
