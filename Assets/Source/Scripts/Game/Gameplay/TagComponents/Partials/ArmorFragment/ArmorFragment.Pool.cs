using System.Collections.Generic;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class ArmorFragment
    {
        public class Pool : MonoMemoryPool<SpawnParameters, ArmorFragment>
        {
            public List<ArmorFragment> ActiveArmorFragments = new();

            protected override void OnCreated(ArmorFragment armorFragment)
            {
                base.OnCreated(armorFragment);
                armorFragment.Initialize();
            }

            protected override void OnSpawned(ArmorFragment armorFragment)
            {
                base.OnSpawned(armorFragment);
                ActiveArmorFragments.Add(armorFragment);
            }

            protected override void OnDespawned(ArmorFragment armorFragment)
            {
                base.OnDespawned(armorFragment);
                ActiveArmorFragments.Remove(armorFragment);
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, ArmorFragment armorFragment)
            {
                armorFragment.Activate(spawnParameters);
            }
        }
    }
}