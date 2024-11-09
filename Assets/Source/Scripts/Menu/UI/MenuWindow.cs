using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Menu.UI
{
    public class MenuWindow : MonoBehaviour
    {
        [Header("Refernces - Buttons")]
        [SerializeField]
        private Button _buttonGame;

        [SerializeField]
        private Button _buttonShop;

        private ShopWindow _shopWindow;

        [Inject]
        private void Construct(ShopWindow shopWindow)
        {
            _shopWindow = shopWindow;
        }

        private void Start()
        {
            _buttonGame.onClick.AddListener(LoadGameScene);
            _buttonShop.onClick.AddListener(OpenShopWindow);
        }

        private void LoadGameScene()
        {
            SceneManager.LoadScene("Game");
        }

        private void OpenShopWindow()
        {
            Close();
            _shopWindow.Open();
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