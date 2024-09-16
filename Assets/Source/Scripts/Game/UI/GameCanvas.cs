using Assets.Source.Scripts.Game.Gameplay.Stage;
using Redcode.Extensions;
using UnityEngine;

namespace Game.UI
{
    public class GameCanvas : MonoBehaviour, IRestartObject
    {
        [Header("Parameters")]
        [SerializeField] private GameEnd _gameEnd;

        [Header("Parameters")]
        [SerializeField] 
        private GameObject[] _gameplayUI;

        public void ActivateGameEnd(GameEndType gameEndType)
        {
            _gameplayUI.ForEach(ui => ui.SetActive(false));
            _gameEnd.ShowGameEndUI(gameEndType);
        }

        public void Restart()
        {
            _gameplayUI.ForEach(ui => ui.SetActive(true));
            _gameEnd.gameObject.SetActive(false);
        }
    }
}