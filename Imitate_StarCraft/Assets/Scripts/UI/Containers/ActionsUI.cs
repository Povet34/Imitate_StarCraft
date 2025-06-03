using System.Collections.Generic;
using System.Linq;
using RTS.Commands;
using RTS.EventBus;
using RTS.Events;
using RTS.Units;
using RTS.UI.Components;
using UnityEngine;
using UnityEngine.Events;

namespace RTS.UI.Containers
{
    public class ActionsUI : MonoBehaviour, IUIElement<HashSet<AbstractCommandable>>
    {
        [SerializeField] private UIActionButton[] actionButtons;
        private HashSet<AbstractCommandable> selectedUnits = new(12);

        public void EnableFor(HashSet<AbstractCommandable> selectedUnits)
        {
            RefreshButtons(selectedUnits);
        }

        public void Disable()
        {
            foreach (UIActionButton button in actionButtons)
            {
                button.Disable();
            }
        }


        private void RefreshButtons(HashSet<AbstractCommandable> selectedUnits)
        {
            HashSet<ActionBase> availableCommands = new(9);

            foreach (AbstractCommandable commandable in selectedUnits)
            {
                availableCommands.UnionWith(commandable.AvailableCommands);
            }

            for (int i = 0; i < actionButtons.Length; i++)
            {
                ActionBase actionForSlot = availableCommands.Where(action => action.Slot == i).FirstOrDefault();

                if (actionForSlot != null)
                {
                    actionButtons[i].EnableFor(actionForSlot, HandleClick(actionForSlot));
                }
                else
                {
                    actionButtons[i].Disable();
                }
            }
        }

        private UnityAction HandleClick(ActionBase action)
        {
            return () => Bus<ActionSelectedEvent>.Raise(new ActionSelectedEvent(action));
        }
    }
}
