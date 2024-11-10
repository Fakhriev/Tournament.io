using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlayerData
    {
        public int softCurrencyAmount;
        public List<PlayerPowerData> powers;

        public PlayerData(int softCurrencyAmount, List<PlayerPowerData> powers)
        {
            this.softCurrencyAmount = softCurrencyAmount;
            this.powers = powers;
        }

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}