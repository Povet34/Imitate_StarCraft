using UnityEngine;

namespace RTS.Commands
{
    public class OverrideCommandsCommand : ActionBase
    {
        [field: SerializeField] public ActionBase[] Commands { get; private set; }
        public override bool CanHandle(CommandContext context)
        {
            throw new System.NotImplementedException();
        }

        public override void Handle(CommandContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}

