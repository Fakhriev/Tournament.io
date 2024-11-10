using Menu.Data;
using Menu.UI.Shop;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu.UI
{
    public class ShopWindow : MonoBehaviour, IInitializable
    {
        [Header("Refernces - Buttons")]
        [SerializeField]
        private Button _buttonMenu;

        private MenuWindow _menuWindow;
        private PowerShopData[] _powerShopItemsData;
        private PowerShopItem.Pool _powerShopItemsPool;

        [Inject]
        private void Construct(MenuWindow menuWindow, PowerShopData[] powerShopItems, PowerShopItem.Pool powerShopItemsPool)
        {
            _menuWindow = menuWindow;
            _powerShopItemsData = powerShopItems;
            _powerShopItemsPool = powerShopItemsPool;
        }

        public void Initialize()
        {
            foreach(var powerShopData in _powerShopItemsData)
            {
                var spawnParameters = new PowerShopItem.SpawnParameters(powerShopData);
                var powerShopItem = _powerShopItemsPool.Spawn(spawnParameters);
            }
        }

        private void Start()
        {
            _buttonMenu.onClick.AddListener(OpenMenuWindow);
        }

        private void OpenMenuWindow()
        {
            Close();
            _menuWindow.Open();
        }

        private void Close()
        {
            gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }
    }
}