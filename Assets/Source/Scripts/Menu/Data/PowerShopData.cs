using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Menu.Data
{
    [Serializable]
    public class PowerShopData
    {
        public string Name;
        public string Description;
        public int Cost;

        [field: ReadOnly, SerializeField]
        public string PowerIdentifier { get; private set; }

        public PowerShopData(string powerIdentifier)
        {
            PowerIdentifier = powerIdentifier;
        }
    }
}