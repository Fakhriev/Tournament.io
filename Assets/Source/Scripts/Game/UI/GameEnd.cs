using Game.Gameplay.StateServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
    public class GameEnd : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] 
        private GameResultsWindow _resultsWindow;

        [Header("Components")]
        [SerializeField] 
        private TextMeshProUGUI _tmpGameEnd;

        [SerializeField] 
        private Button _btnRestart;

        private GameRestarter _gameRestarter;

        [Inject]
        private void Construct(GameRestarter gameRestarter)
        {
            _gameRestarter = gameRestarter;
        }

        private void Start()
        {
            _btnRestart.onClick.AddListener(RestartGame);
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
    }

    public enum GameEndType
    {
        Victory,
        Lose,
        Tie
    }
}