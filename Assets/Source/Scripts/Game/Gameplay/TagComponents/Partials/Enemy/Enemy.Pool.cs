using System.Collections.Generic;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class Enemy
    {
        public class Pool : MonoMemoryPool<SpawnParameters, Enemy>
        {
            public List<Enemy> ActiveEnemies = new();

            protected override void OnSpawned(Enemy enemy)
            {
                base.OnSpawned(enemy);
                ActiveEnemies.Add(enemy);
            }

            protected override void OnDespawned(Enemy enemy)
            {
                base.OnDespawned(enemy);
                ActiveEnemies.Remove(enemy);
                enemy.Deactivate();
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, Enemy enemy)
            {
                enemy.Activate(spawnParameters);
            }
        }
    }
}