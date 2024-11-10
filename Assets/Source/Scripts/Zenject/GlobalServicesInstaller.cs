using UnityEngine;
using System.Collections.Generic;
using ScriptableObjects;
using Services;
using Data;

namespace Zenject
{
    public class GlobalServicesInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField]
        private StartPlayerData _startPlayerData;

        [Header("Debug")]
        [SerializeField]
        private PlayerData _playerData;

        public override void InstallBindings()
        {
            var startPlayerData = _startPlayerData.PlayerData;
            _playerData = new PlayerData(startPlayerData.softCurrencyAmount, new List<PlayerPowerData>(startPlayerData.powers));

            var powersService = new PowersService(_playerData);
            var softCurrencyService = new SoftCurrencyService(_playerData);

            Container.BindInstance(softCurrencyService);
            Container.BindInstance(powersService);
        }
    }
}