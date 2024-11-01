using System.Collections.Generic;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class LightningStrikeProjectile
    {
        public class Pool : MonoMemoryPool<SpawnParameters, LightningStrikeProjectile>
        {
            public List<LightningStrikeProjectile> ActiveProjectiles = new();

            protected override void OnCreated(LightningStrikeProjectile projectile)
            {
                base.OnCreated(projectile);
                projectile.Initialize();
            }

            protected override void OnSpawned(LightningStrikeProjectile projectile)
            {
                base.OnSpawned(projectile);
                ActiveProjectiles.Add(projectile);
            }

            protected override void OnDespawned(LightningStrikeProjectile projectile)
            {
                base.OnDespawned(projectile);
                ActiveProjectiles.Remove(projectile);
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, LightningStrikeProjectile projectile)
            {
                projectile.Activate(spawnParameters);
            }
        }
    }
}