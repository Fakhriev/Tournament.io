using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;
using TMPro;
using Game.Gameplay.StateServices;

namespace Game.UI
{
    public class GameEnd : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] 
        private GameResultsWindow _resultsWindow;

        [Header("Components - Texts")]
        [SerializeField] 
        private TextMeshProUGUI _tmpGameEnd;

        [Header("Components - Buttons")]
        [SerializeField]
        private Button _buttonRestart;

        [SerializeField]
        private Button _buttonMenu;

        private GameRestarter _gameRestarter;

        [Inject]
        private void Construct(GameRestarter gameRestarter)
        {
            _gameRestarter = gameRestarter;
        }

        private void Start()
        {
            _buttonRestart.onClick.AddListener(RestartGame);
            _buttonMenu.onClick.AddListener(LoadMenuScene);
        }

        public void ShowGameEndUI(GameEndType gameEndType)
        {
            _tmpGameEnd.text = $"Game End: [{gameEndType}]";
            
            _resultsWindow.Show(gameEndType);
            
            gameObject.SetActive(true);
        }

        private void RestartGame()
        {
            _gameRestarter.RestartGame();
        }

        private void LoadMenuScene()
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public enum GameEndType
    {
        Victory,
        Lose,
        Tie
    }
}