using RTS.Environment;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEditor.Build;

namespace RTS.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Gather Supplies", story: "[Unit] gathers [Amount] supplies form [GatherableSupplies] .", category: "Action/Units", id: "bd86ffdbf425863462be06d84bf7b27d")]
    public partial class GatherSuppliesAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Unit;
        [SerializeReference] public BlackboardVariable<int> Amount;
        [SerializeReference] public BlackboardVariable<GatherableSupply> GatherableSupplies;

        private float enterTime;

        protected override Status OnStart()
        {
            if (GatherableSupplies.Value == null)
            {
                return Status.Failure;
            }


            enterTime = Time.time;

            GatherableSupplies.Value.BeginGatherg();
            return Status.Running;
        }

        protected override Status OnUpdate()
        {
            if (GatherableSupplies.Value.Supply.BaseGatherTime + enterTime <= Time.time)
            {
                return Status.Success;
            }

            return Status.Running;
        }

        protected override void OnEnd()
        {
            if (GatherableSupplies.Value == null) return;

            if (CurrentStatus == Status.Success)
            {
                Amount.Value = GatherableSupplies.Value.EndGather();
            }
            else
            {
                GatherableSupplies.Value.AbortGather();
            }
        }

    }
}