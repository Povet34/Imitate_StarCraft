using RTS.EventBus;
using RTS.Units;

namespace RTS.Event
{
    public class UnitDeselectedEvent : IEvent
    {
        public UnitDeselectedEvent(ISelectable unit)
        {
            Unit = unit;
        }

        public ISelectable Unit { get; private set; }
    }
}
