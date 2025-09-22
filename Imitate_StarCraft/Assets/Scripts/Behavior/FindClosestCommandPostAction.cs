using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using RTS.Units;
using System.Collections.Generic;

namespace RTS.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Find Closest Command Post", story: "[Unit] finds nearest [CommandPost] .", category: "Action/Units", id: "36aeca513a4121792b33b2e63efb386d")]
    public partial class FindClosestCommandPostAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Unit;
        [SerializeReference] public BlackboardVariable<GameObject> CommandPost;
        [SerializeReference] public BlackboardVariable<float> SearchRadius = new(10);
        [SerializeReference] public BlackboardVariable<BuildingSO> CommandPostBuilding;

        protected override Status OnStart()
        {
            Collider[] colliders = Physics.OverlapSphere(Unit.Value.transform.position, SearchRadius.Value, LayerMask.GetMask("Buildings"));

            List<BaseBuilding> nearbyCommandPost = new();
            foreach (var collider in colliders)
            {
                if(collider.TryGetComponent(out BaseBuilding building) && building.UnitSO.Equals(CommandPostBuilding.Value))
                {
                    nearbyCommandPost.Add(building);
                }
            }

            if(nearbyCommandPost.Count == 0)
            {
                return Status.Failure;
            }

            CommandPost.Value = nearbyCommandPost[0].gameObject;
            return Status.Success;
        }

        protected override Status OnUpdate()
        {
            return Status.Success;
        }

        protected override void OnEnd()
        {
        }
    }
}

