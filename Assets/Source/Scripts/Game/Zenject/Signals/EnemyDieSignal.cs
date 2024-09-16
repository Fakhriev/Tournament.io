using Game.Gameplay.TagComponents;
using UnityEngine;

namespace Game.Zenject.Signals
{
    public class EnemyDieSignal
    {
        public Enemy Enemy { get; private set; }

        public EnemyDieSignal(Enemy enemy)
        {
            Enemy = enemy;
        }
    }
}