using Menu.UI.Shop;
using Pools;
using UnityEngine;
using Zenject;

namespace Menu.Zenject
{
    public class MenuPoolsInstaller : MonoInstaller
    {
        [Header("Menu Objects Parents")]
        [SerializeField]
        private Transform _powerShopItemParent;

        [Header("Prefabs")]
        [SerializeField]
        private GameObject _powerShopItemPrefab;

        private PoolParameters _powerShopItemsPoolParameters;

        [Inject]
        private void Construct(PoolParameters powerShopItemsPoolParameters)
        {
            _powerShopItemsPoolParameters = powerShopItemsPoolParameters;
        }

        public override void InstallBindings()
        {
            Container
                .BindMemoryPool<PowerShopItem, PowerShopItem.Pool>()
                .WithInitialSize(_powerShopItemsPoolParameters.InitialSize)
                .WithMaxSize(_powerShopItemsPoolParameters.MaxSize)
                .FromComponentInNewPrefab(_powerShopItemPrefab)
                .WithGameObjectName(nameof(PowerShopItem))
                .UnderTransform(_powerShopItemParent);
        }
    }
}