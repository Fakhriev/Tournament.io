using Game.Gameplay.TagComponents;
using UnityEngine;

namespace Game.Zenject.Signals
{
    public class BossSpawnSignal
    {
        public Boss Boss { get; private set; }

        public BossSpawnSignal(Boss boss)
        {
            Boss = boss;
        }
    }
}
