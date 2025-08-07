using RTS.Environment;
using RTS.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS.Events
{
    public struct SupplyEvent : IEvent
    {
        public SupplyEvent(int aount, SupplySO supplySO)
        {
            Aount = aount;
            SupplySO = supplySO;
        }

        public int Aount { get; private set; }
        public SupplySO SupplySO { get; private set; }
    }
}
