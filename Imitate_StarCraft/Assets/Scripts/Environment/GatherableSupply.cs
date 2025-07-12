using UnityEngine;
namespace RTS.Environment
{
    public class GatherableSupply : MonoBehaviour, IGatherable
    {
        public SupplySO Supply { get; private set; }

        public int Amount { get; private set; }

        public bool IsBusy { get; private set; }

        public bool BeginGatherg()
        {
            if (IsBusy)
            {
                return false;
            }

            IsBusy = true;
            return true;
        }

        public int EndGather()
        {
            IsBusy = false;

            int amountGathered = Mathf.Min(Supply.AmountPerGather, Amount);
            Amount -= amountGathered;

            if(Amount <= 0)
            {
                Destroy(gameObject);
            }

            return amountGathered;
        }
    }
}