using RTS.Environment;
using RTS.Utilities;
using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEditor.Build;
using UnityEngine;
using Action = Unity.Behavior.Action;

namespace RTS.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Gather Supplies", story: "[Unit] gathers [Amount] supplies form [GatherableSupplies] .", category: "Action/Units", id: "bd86ffdbf425863462be06d84bf7b27d")]
    public partial class GatherSuppliesAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Unit;
        [SerializeReference] public BlackboardVariable<int> Amount;
        [SerializeReference] public BlackboardVariable<GatherableSupply> GatherableSupplies;

        private Animator animator;
        private float enterTime;

        protected override Status OnStart()
        {
            if (GatherableSupplies.Value == null)
            {
                return Status.Failure;
            }
            enterTime = Time.time;

            if (Unit.Value.TryGetComponent(out animator))
            {
                animator.SetBool(AnimationConstants.IS_GATHERING, true);
            }
            GatherableSupplies.Value.BeginGather();
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
            if (animator != null)
            {
                animator.SetBool(AnimationConstants.IS_GATHERING, false);
            }

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