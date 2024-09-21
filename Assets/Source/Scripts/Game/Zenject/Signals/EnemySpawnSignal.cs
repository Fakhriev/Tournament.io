using Game.Gameplay.TagComponents;
using UnityEngine;

namespace Game.Zenject.Signals
{
    public class EnemySpawnSignal
    {
        public Enemy Enemy { get; private set; }

        public EnemySpawnSignal(Enemy enemy)
        {
            Enemy = enemy;
        }
    }
}
