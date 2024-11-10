using System.Collections.Generic;
using Zenject;

namespace Menu.UI.Shop
{
    public partial class ShopPowerItem
    {
        public class Pool : MonoMemoryPool<SpawnParameters, ShopPowerItem>
        {
            public List<ShopPowerItem> ActiveItems = new();

            protected override void OnSpawned(ShopPowerItem item)
            {
                base.OnSpawned(item);
                ActiveItems.Add(item);
            }

            protected override void OnDespawned(ShopPowerItem item)
            {
                base.OnDespawned(item);
                ActiveItems.Remove(item);
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, ShopPowerItem item)
            {
                base.Reinitialize(spawnParameters, item);
                item.Activate(spawnParameters);
            }
        }
    }
}