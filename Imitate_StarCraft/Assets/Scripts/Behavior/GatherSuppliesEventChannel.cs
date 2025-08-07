using RTS.Environment;
using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

namespace RTS.Behavior
{
#if UNITY_EDITOR
    [CreateAssetMenu(menuName = "Behavior/Event Channels/GatherSuppliesEventChannel")]
#endif
    [Serializable, GeneratePropertyBag]
    [EventChannelDescription(name: "GatherSuppliesEventChannel", message: "[Self] gathers [Amount] to [Supplies] .", category: "Events", id: "c3e2feb1c284ebf054c526d611f5e9ed")]
    public sealed partial class GatherSuppliesEventChannel : EventChannel<GameObject, int, SupplySO> { }

}