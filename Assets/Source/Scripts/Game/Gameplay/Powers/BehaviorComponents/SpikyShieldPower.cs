using Game.Gameplay.TagComponents;
using System;
using Zenject;

namespace Game.Gameplay.Powers.BehaviorComponents
{
    public class SpikyShieldPower : PowerBase
    {
        private SpikyShieldObject.Pool _shieldsPool;
        private SpikyShieldPowerParameters _parameters;

        [Inject]
        private void Construct(SpikyShieldObject.Pool shieldsPool, SpikyShieldPowerParameters parameters)
        {
            _parameters = parameters;
            _shieldsPool = shieldsPool;
        }

        private void Start()
        {
            CreateShield();
        }

        private void CreateShield()
        {
            var spawnParameters = new SpikyShieldObject.SpawnParameters(_character);
            var shield = _shieldsPool.Spawn(spawnParameters);
        }
    }

    [Serializable]
    public struct SpikyShieldPowerParameters
    {

    }
}