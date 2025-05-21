using RTS.EventBus;
using RTS.Units;


namespace RTS.Events
{
    public struct UnitSelectedEvent : IEvent
    {
        public UnitSelectedEvent(ISelectable unit)
        {
            Unit = unit;
        }

        public ISelectable Unit { get; private set; }
    }
}
