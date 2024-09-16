using System.Collections.Generic;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class Boss
    {
        public class Pool : MonoMemoryPool<SpawnParameters, Boss>
        {
            private List<Boss> BossesList = new();

            protected override void OnCreated(Boss boss)
            {
                base.OnCreated(boss);
            }

            protected override void OnSpawned(Boss boss)
            {
                base.OnSpawned(boss);
                BossesList.Add(boss);
            }

            protected override void OnDespawned(Boss boss)
            {
                base.OnDespawned(boss);
                BossesList.Remove(boss);
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, Boss boss)
            {
                boss.Activate(spawnParameters);
            }
        }
    }
}