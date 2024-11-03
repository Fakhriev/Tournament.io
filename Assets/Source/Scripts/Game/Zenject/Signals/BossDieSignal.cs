using Game.Gameplay.Abstracts;
using Game.Gameplay.TagComponents;

namespace Game.Zenject.Signals
{
    public class BossDieSignal
    {
        public Boss Boss { get; private set; }
        public IHitSource HitSource { get; private set; }

        public BossDieSignal(Boss boss, IHitSource hitSource)
        {
            Boss = boss;
            HitSource = hitSource;
        }
    }
}