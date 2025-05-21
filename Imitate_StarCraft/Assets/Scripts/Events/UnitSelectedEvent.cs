using RTS.EventBus;
using RTS.Units;
using UnityEngine;


namespace RTS.Events
{
    public class UnitSelectedEvent : IEvent
    {
        public UnitSelectedEvent(ISelectable unit)
        {
            Unit = unit;
        }

        public ISelectable Unit { get; private set; }
    }
}
