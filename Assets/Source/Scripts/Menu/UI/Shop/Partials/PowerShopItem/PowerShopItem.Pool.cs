using System.Collections.Generic;
using Zenject;

namespace Menu.UI.Shop
{
    public partial class PowerShopItem
    {
        public class Pool : MonoMemoryPool<SpawnParameters, PowerShopItem>
        {
            public List<PowerShopItem> ActiveItems = new();

            protected override void OnSpawned(PowerShopItem item)
            {
                base.OnSpawned(item);
                ActiveItems.Add(item);
            }

            protected override void OnDespawned(PowerShopItem item)
            {
                base.OnDespawned(item);
                ActiveItems.Remove(item);
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, PowerShopItem item)
            {
                base.Reinitialize(spawnParameters, item);
                item.Activate(spawnParameters);
            }
        }
    }
}