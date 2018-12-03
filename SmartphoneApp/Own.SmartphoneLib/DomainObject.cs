using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Own.SmartphoneLib
{
    public abstract class DomainObject
    {
        public Guid Id { get; set; }

        public DomainObject()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
