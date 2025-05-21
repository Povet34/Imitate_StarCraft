using RTS.EventBus;
using RTS.Units;

namespace RTS.Events
{
    public struct UnitDeselectedEvent : IEvent
    {
        public UnitDeselectedEvent(ISelectable unit)
        {
            Unit = unit;
        }

        public ISelectable Unit { get; private set; }
    }
}
