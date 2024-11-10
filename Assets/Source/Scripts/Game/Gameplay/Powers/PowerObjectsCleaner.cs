using Game.Gameplay.StateServices;
using Game.Gameplay.TagComponents;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers
{
    public class PowerObjectsCleaner : MonoBehaviour, IPreRestartObject
    {
        private SpikyShieldObject.Pool _spikyShieldPool;
        private AppleTrashProjectile.Pool _appleTrashProjectilesPool;
        private LightningStrikeProjectile.Pool _lightningStrikeProjectilesPool;

        [Inject]
        private void Construct(SpikyShieldObject.Pool spikyShieldPool, 
            AppleTrashProjectile.Pool appleTrashProjectilesPool,
            LightningStrikeProjectile.Pool lightningStrikeProjectilesPool)
        {
            _spikyShieldPool = spikyShieldPool;
            _appleTrashProjectilesPool = appleTrashProjectilesPool;
            _lightningStrikeProjectilesPool = lightningStrikeProjectilesPool;
        }

        public void PreRestart()
        {
            List<SpikyShieldObject> spikyShieldObjects = new(_spikyShieldPool.ActiveSpikyShields);

            foreach (var activeShield in spikyShieldObjects)
                _spikyShieldPool.Despawn(activeShield);


            List<AppleTrashProjectile> appleTrashProjectiles = new(_appleTrashProjectilesPool.ActiveProjectiles);

            foreach (var activeAppleTrashPorjectiles in appleTrashProjectiles)
                _appleTrashProjectilesPool.Despawn(activeAppleTrashPorjectiles);


            List<LightningStrikeProjectile> lightningStrikeProjectiles = new(_lightningStrikeProjectilesPool.ActiveProjectiles);

            foreach (var activeLightningPorjectiles in lightningStrikeProjectiles)
                _lightningStrikeProjectilesPool.Despawn(activeLightningPorjectiles);
        }
    }
}