using Pools;
using UnityEngine;
using Zenject;

namespace Menu.Zenject.ScriptableObjectsInstaller
{
    [CreateAssetMenu(fileName = nameof(ShopElementsPoolSettingsInstaller), menuName = "Installers/Shop Elements Pools Settings Installer")]
    public class ShopElementsPoolSettingsInstaller : ScriptableObjectInstaller<ShopElementsPoolSettingsInstaller>
    {
        [Header("Menu Pools Parameters")]
        [SerializeField]
        private PoolParameters _powerShopItemsPoolParameters;

        public override void InstallBindings()
        {
            Container.BindInstance(_powerShopItemsPoolParameters);
        }
    }
}