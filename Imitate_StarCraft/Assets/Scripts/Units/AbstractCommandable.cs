using RTS.Commands;
using RTS.EventBus;
using RTS.Events;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace RTS.Units
{
    public abstract class AbstractCommandable : MonoBehaviour, ISelectable
    {
        [field: SerializeField] public int CurrentHealth { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public ActionBase[] AvailableCommands { get; private set; }
        [SerializeField] private DecalProjector decalProjector;
        [field: SerializeField] public UnitSO UnitSO { get; private set; }

        private ActionBase[] initalCommands;

        protected virtual void Start()
        {
            MaxHealth = UnitSO.Health;
            CurrentHealth = UnitSO.Health;

            initalCommands = AvailableCommands;
        }

        public void Select()
        {
            if (decalProjector != null)
            {
                decalProjector.gameObject.SetActive(true);
            }

            Bus<UnitSelectedEvent>.Raise(new UnitSelectedEvent(this));
        }

        public void Deselect()
        {
            if (decalProjector != null)
            {
                decalProjector.gameObject.SetActive(false);
            }

           SetCommandOvrrides(null);

            Bus<UnitDeselectedEvent>.Raise(new UnitDeselectedEvent(this));
        }

        public void SetCommandOvrrides(ActionBase[] commands)
        {
            if(commands == null || commands.Length == 0)
            {
                AvailableCommands = initalCommands;
                return;
            }

            AvailableCommands = commands;
        }
    }
}
