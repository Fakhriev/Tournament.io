using System;
using UnityEngine;

namespace Game.Gameplay.GameServices
{
    [Serializable]
    public class SoftCurrency
    {
        [SerializeField]
        private int _value;

        public int Amount => _value;

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