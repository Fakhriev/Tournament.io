using Game.Gameplay.TagComponents;
using UnityEngine;

namespace Game.Zenject.Signals
{
    public class BossDieSignal
    {
        public Boss Boss { get; private set; }

        public BossDieSignal(Boss boss)
        {
            Boss = boss;
        }
    }
}