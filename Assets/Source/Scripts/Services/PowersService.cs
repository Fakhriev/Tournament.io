using Data;
using System;
using UnityEngine;

namespace Services
{
    [Serializable]
    public class PowersService
    {
        [HideInInspector]
        private PlayerData _playerData;

        public PowersService(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public void SetUnlocked(string powerIdentifier)
        {
            foreach (var power in _playerData.powers)
            {
                if (power.identifier.Equals(powerIdentifier) == false)
                {
                    continue;
                }

                power.state = PlayerPowerData.State.Unlocked;
            }
        }

        public void SetEquiped(string powerIdentifier)
        {
            foreach (var power in _playerData.powers)
            {
                if (power.identifier.Equals(powerIdentifier) == false)
                {
                    if (power.state == PlayerPowerData.State.Equiped)
                        power.state = PlayerPowerData.State.Unlocked;

                    continue;
                }

                power.state = PlayerPowerData.State.Equiped;
            }
        }

        public PlayerPowerData Get(string powerIdentifier)
        {
            foreach (var power in _playerData.powers)
            {
                if (power.identifier.Equals(powerIdentifier))
                {
                    return power;
                }
            }

            var newPower = new PlayerPowerData(powerIdentifier);
            _playerData.powers.Add(newPower);
            return newPower;
        }

        public PlayerPowerData GetEquiped()
        {
            foreach (var power in _playerData.powers)
            {
                if (power.state == PlayerPowerData.State.Equiped)
                {
                    return power;
                }
            }

            throw new Exception("No Equiped Power in PlayerData");
        }
    }
}