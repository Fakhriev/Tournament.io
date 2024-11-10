using Menu.Data;
using Menu.UI.Shop;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu.UI
{
    public class ShopWindow : MonoBehaviour, IInitializable
    {
        [Header("Components - Texts")]
        [SerializeField]
        private TextMeshProUGUI _tmpSoftCurrencyAmount;

        [Header("Components - Buttons")]
        [SerializeField]
        private Button _buttonMenu;

        private MenuWindow _menuWindow;
        private SoftCurrencyService _softCurrencyService;

        private ShopPowerItem.Pool _powerShopItemsPool;
        private ShopPowerData[] _shopPowersData;

        [Inject]
        private void Construct(MenuWindow menuWindow, SoftCurrencyService softCurrencyService,
            ShopPowerItem.Pool powerShopItemsPool, ShopPowerData[] shopPowersData)
        {
            _menuWindow = menuWindow;
            _softCurrencyService = softCurrencyService;
            
            _powerShopItemsPool = powerShopItemsPool;
            _shopPowersData = shopPowersData;
        }

        public void Initialize()
        {
            for (int i = 0; i < _shopPowersData.Length; i++)
            {
                var powerShopData = _shopPowersData[i];
                var spawnParameters = new ShopPowerItem.SpawnParameters(powerShopData);
                var powerShopItem = _powerShopItemsPool.Spawn(spawnParameters);
                powerShopItem.transform.SetAsLastSibling();
            }

            UpdateState();
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
            UpdateState();
        }

        public void UpdateState()
        {
            foreach (var shopPowerItem in _powerShopItemsPool.ActiveItems)
            {
                shopPowerItem.UpdateVisualState();
            }

            _tmpSoftCurrencyAmount.text = _softCurrencyService.Amount.ToString();
        }
    }
}