using Game.Gameplay.Abstracts;
using Game.Gameplay.TagComponents;

namespace Game.Zenject.Signals
{
    public class EnemyDieSignal
    {
        public Enemy Enemy { get; private set; }
        public IHitSource HitSource { get; private set; }

        public EnemyDieSignal(Enemy enemy, IHitSource hitSource)
        {
            Enemy = enemy;
            HitSource = hitSource;
        }
    }
}