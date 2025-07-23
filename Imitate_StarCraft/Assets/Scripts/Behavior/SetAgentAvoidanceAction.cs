using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

namespace RTS.Behavior
{
    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "Set Agent Avoidance", story: "Set [Agent] avoidance quality to [AvoidanceQuality] .", category: "Action/Navigation", id: "cfc08d2e20ffe33cfc2ac1a161ff6a0f")]
    public partial class SetAgentAvoidanceAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Agent;
        [SerializeReference] public BlackboardVariable<int> AvoidanceQuality;

        protected override Status OnStart()
        {
            if (!Agent.Value.TryGetComponent(out NavMeshAgent agnet) || AvoidanceQuality > 4 || AvoidanceQuality < 0)
            {
                return Status.Failure;
            }

            agnet.obstacleAvoidanceType = (ObstacleAvoidanceType)AvoidanceQuality.Value;
            return Status.Success;
        }
    }
}
