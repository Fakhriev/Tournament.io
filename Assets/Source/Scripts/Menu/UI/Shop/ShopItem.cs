using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.UI.Shop
{
    public class ShopItem : MonoBehaviour
    {
        [Header("Components - Texts")]
        [SerializeField] 
        private TextMeshProUGUI _tmpName;

        [SerializeField]
        private TextMeshProUGUI _tmpDescription;

        [SerializeField]
        private TextMeshProUGUI _tmpState;

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

        private void Start()
        {
            _buttonPurchase.onClick.AddListener(OnPurchaseClicked);
            _buttonEquip.onClick.AddListener(OnEquippedClicked);
        }

        public void Initialize()
        {
            //Сюда приходить информация:
            //1) О самом копье: название, описание, стоимость
            //2) Данные игрока о копье: закрыто, куплено, экипировано
        }

        private void OnPurchaseClicked()
        {

        }

        private void OnEquippedClicked()
        {

        }
    }
}