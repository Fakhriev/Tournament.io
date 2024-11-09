using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Menu.UI
{
    public class ShopWindow : MonoBehaviour
    {
        [Header("Refernces - Buttons")]
        [SerializeField]
        private Button _buttonMenu;

        private MenuWindow _menuWindow;

        [Inject]
        private void Construct(MenuWindow menuWindow)
        {
            _menuWindow = menuWindow;
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