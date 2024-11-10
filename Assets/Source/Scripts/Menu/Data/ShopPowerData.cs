using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Menu.Data
{
    [Serializable]
    public class ShopPowerData
    {
        public string Name;
        public string Description;
        public int Cost;

        [field: ReadOnly, SerializeField]
        public string PowerIdentifier { get; private set; }

        public ShopPowerData(string powerIdentifier)
        {
            PowerIdentifier = powerIdentifier;
        }

        [Button]
        private void CopyIdentifier()
        {
            GUIUtility.systemCopyBuffer = PowerIdentifier;
        }
    }
}