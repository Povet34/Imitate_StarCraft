using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

namespace RTS.Behavior
{

    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Move to TargetLocation", story: "[Agent] moves to [TargetLocation] .", category: "Action", id: "6122d85655fc043b36dcef1a8d6f9556")]
    public partial class MoveToTargetLocationAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Agent;
        [SerializeReference] public BlackboardVariable<Vector3> TargetLocation;

        private NavMeshAgent agent;


        protected override Status OnStart()
        {
            if (!Agent.Value.TryGetComponent(out agent))
            {
                Debug.LogError("Agent does not have a NavMeshAgent component.");
                return Status.Failure;
            }

            if (Vector3.Distance(agent.transform.position, TargetLocation.Value) <= agent.stoppingDistance)
            {
                return Status.Success;
            }

            agent.SetDestination(TargetLocation.Value);
            return Status.Running;
        }

        protected override Status OnUpdate()
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                return Status.Success;
            }

            return Status.Running;
        }

        protected override void OnEnd()
        {
        }
    }
}