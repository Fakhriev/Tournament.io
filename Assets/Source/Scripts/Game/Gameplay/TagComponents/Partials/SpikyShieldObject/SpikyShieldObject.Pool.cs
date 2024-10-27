using System.Collections.Generic;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class SpikyShieldObject
    {
        public class Pool : MonoMemoryPool<SpawnParameters, SpikyShieldObject>
        {
            public List<SpikyShieldObject> ActiveSpikyShields = new();

            protected override void OnCreated(SpikyShieldObject spikyShield)
            {
                base.OnCreated(spikyShield);
                spikyShield.Initialize();
            }

            protected override void OnSpawned(SpikyShieldObject spikyShield)
            {
                base.OnSpawned(spikyShield);
                ActiveSpikyShields.Add(spikyShield);
            }

            protected override void OnDespawned(SpikyShieldObject spikyShield)
            {
                base.OnDespawned(spikyShield);
                ActiveSpikyShields.Remove(spikyShield);
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, SpikyShieldObject spikyShield)
            {
                spikyShield.Activate(spawnParameters);
            }
        }
    }
}