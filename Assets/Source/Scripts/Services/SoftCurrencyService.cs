using Data;
using System;
using UnityEngine;

namespace Services
{
    [Serializable]
    public class SoftCurrencyService
    {
        [HideInInspector]
        private PlayerData _playerData;

        private int _value
        {
            get => _playerData.softCurrencyAmount;
            set => _playerData.softCurrencyAmount = value;
        }

        public int Amount => _value;

        public SoftCurrencyService(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public bool IsEnough(int amount)
        {
            return _value >= amount;
        }

        public bool TryToSpend(int amount)
        {
            if (IsEnough(amount) == false)
                return false;

            _value -= amount;
            return true;
        }

        public void Add(int amount)
        {
            _value += amount;
        }
    }
}