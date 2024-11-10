using Data;
using Menu.Data;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu.UI.Shop
{
    public partial class ShopPowerItem : MonoBehaviour
    {
        [Header("Components - Texts")]
        [SerializeField] 
        private TextMeshProUGUI _tmpName;

        [SerializeField]
        private TextMeshProUGUI _tmpDescription;

        [SerializeField]
        private TextMeshProUGUI _tmpCost;

        [Header("Components - Buttons")]
        [SerializeField]
        private Button _buttonPurchase;

        [SerializeField]
        private Button _buttonEquip;

        [Header("Components - States")]
        [SerializeField]
        private GameObject _lockedState;

        [SerializeField]
        private GameObject _unlockedState;

        [SerializeField]
        private GameObject _equipedState;

        private ShopWindow _shopWindow;

        private PowersService _powersService;
        private SoftCurrencyService _softCurrencyService;

        private ShopPowerData _shopPowerData;
        private PlayerPowerData _playerPowerData;

        [Inject]
        private void Construct(ShopWindow shopWindow, PowersService powersService, SoftCurrencyService softCurrencyService)
        {
            _shopWindow = shopWindow;
            _powersService = powersService;
            _softCurrencyService = softCurrencyService;
        }

        private void Start()
        {
            _buttonPurchase.onClick.AddListener(OnPurchaseClicked);
            _buttonEquip.onClick.AddListener(OnEquippedClicked);
        }

        public void Activate(SpawnParameters spawnParameters)
        {
            _shopPowerData = spawnParameters.ShopPowerData;
            _playerPowerData = _powersService.Get(_shopPowerData.PowerIdentifier);

            gameObject.name = $"{nameof(ShopPowerItem)} - [{_shopPowerData.PowerIdentifier}]";
            
            _tmpName.text = _shopPowerData.Name;
            _tmpDescription.text = _shopPowerData.Description;
            _tmpCost.text = _shopPowerData.Cost.ToString();
        }

        private void OnPurchaseClicked()
        {
            if (_softCurrencyService.TryToSpend(_shopPowerData.Cost))
            {
                EquipThisPower();
            }
        }

        private void OnEquippedClicked()
        {
            EquipThisPower();
        }

        private void EquipThisPower()
        {
            _powersService.SetEquiped(_shopPowerData.PowerIdentifier);
            _shopWindow.UpdateState();
        }

        public void UpdateVisualState()
        {
            _lockedState.SetActive(_playerPowerData.state == PlayerPowerData.State.Locked);
            _unlockedState.SetActive(_playerPowerData.state == PlayerPowerData.State.Unlocked);
            _equipedState.SetActive(_playerPowerData.state == PlayerPowerData.State.Equiped);
        }
    }
}