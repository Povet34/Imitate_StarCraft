using RTS.Environment;
using RTS.Units;
using System;
using UnityEngine;

namespace RTS.Commands
{
    [CreateAssetMenu(fileName = "Gather Action", menuName = "AI/Commands/Gather", order = 105)]
    public class GatherCommand : ActionBase
    {
        public override bool CanHandle(CommandContext context)
        {
            return context.Commandable is Worker
                && context.Hit.collider != null
                && context.Hit.collider.TryGetComponent(out GatherableSupply _);
        }

        public override void Handle(CommandContext context)
        {
            if (context.Commandable is Worker worker
                && context.Hit.collider.TryGetComponent(out GatherableSupply supply))
            {
                worker.Gather(supply);
            }
        }
    }
}
