using System.Collections.Generic;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class AppleTrashProjectile
    {
        public class Pool : MonoMemoryPool<SpawnParameters, AppleTrashProjectile>
        {
            public List<AppleTrashProjectile> ActiveProjectiles = new();

            protected override void OnCreated(AppleTrashProjectile projectile)
            {
                base.OnCreated(projectile);
                projectile.Initialize();
            }

            protected override void OnSpawned(AppleTrashProjectile projectile)
            {
                base.OnSpawned(projectile);
                ActiveProjectiles.Add(projectile);
            }

            protected override void OnDespawned(AppleTrashProjectile projectile)
            {
                base.OnDespawned(projectile);
                ActiveProjectiles.Remove(projectile);
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, AppleTrashProjectile projectile)
            {
                projectile.Activate(spawnParameters);
            }
        }
    }
}