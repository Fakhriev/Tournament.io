using System.Collections.Generic;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class Enemy
    {
        public class Pool : MonoMemoryPool<SpawnParameters, Enemy>
        {
            public List<Enemy> ActiveEnemies = new();

            protected override void OnSpawned(Enemy item)
            {
                base.OnSpawned(item);
                ActiveEnemies.Add(item);
            }

            protected override void OnDespawned(Enemy item)
            {
                base.OnDespawned(item);
                ActiveEnemies.Remove(item);
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, Enemy enemy)
            {
                enemy.Activate(spawnParameters);
            }
        }
    }
}