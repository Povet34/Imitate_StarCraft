using UnityEngine;

namespace RTS.Units
{
    [CreateAssetMenu(fileName = "UnitSO", menuName = "Units/Unit")]
    public class UnitSO : ScriptableObject
    {
        [field: SerializeField] public int Health { get; private set; } = 100;
    }
}