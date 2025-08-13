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
        public SupplyEvent(int amount, SupplySO supplySO)
        {
            Amount = amount;
            Supply = supplySO;
        }

        public int Amount { get; private set; }
        public SupplySO Supply { get; private set; }
    }
}
