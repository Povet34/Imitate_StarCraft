using System;
using Unity.Behavior;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Action = Unity.Behavior.Action;

namespace RTS.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Move to Target GameObject", story: "[Agent] moves to [TargetGameObject] .", category: "Action/Navigation", id: "870bad9007d43d40f4c13174ecd80778")]
    public partial class MoveToTargetGameObjectAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Agent;
        [SerializeReference] public BlackboardVariable<GameObject> TargetGameObject;

        private NavMeshAgent agent;

        protected override Status OnStart()
        {
            if (!Agent.Value.TryGetComponent(out agent))
            {
                Debug.LogError("Agent does not have a NavMeshAgent component.");
                return Status.Failure;
            }

            Vector3 targetPosition = GetTargetPosition();
            if (Vector3.Distance(Agent.Value.transform.position, targetPosition) < agent.stoppingDistance)
            {
                return Status.Success; // Already at the target position
            }

            agent.SetDestination(targetPosition);
            return Status.Running;
        }



        protected override Status OnUpdate()
        {
            if (agent == null)
            {
                Debug.LogError("NavMeshAgent is not initialized.");
                return Status.Failure;
            }
            if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
            {
                return Status.Running; // Still moving towards the target
            }
            return Status.Success; // Reached the target position
        }

        private Vector3 GetTargetPosition()
        {
            Vector3 targetPosition;
            if (TargetGameObject.Value.TryGetComponent(out Collider collider))
            {
                targetPosition = collider.ClosestPoint(agent.transform.position);
            }
            else
            {
                targetPosition = TargetGameObject.Value.transform.position;
            }

            return targetPosition;
        }
    }
}