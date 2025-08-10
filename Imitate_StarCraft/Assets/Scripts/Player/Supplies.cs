using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace RTS.Player
{
    public class Supplies : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI mineralsText;
        [SerializeField] TextMeshProUGUI gasText;
        [SerializeField] TextMeshProUGUI popuplationText;

        public static int Minerals { get; private set; }
        public static int Gas { get; private set; }
        public static int Population { get; private set; }
        public static int PopulationLimit { get; private set; }
    }
}
