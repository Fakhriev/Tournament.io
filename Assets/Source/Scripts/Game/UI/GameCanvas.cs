using Game.Gameplay.StateServices;
using Redcode.Extensions;
using UnityEngine;

namespace Game.UI
{
    public class GameCanvas : MonoBehaviour, IRestartObject
    {
        [Header("Game End UI")]
        [SerializeField] 
        private GameEnd _gameEnd;

        [Header("Game UI")]
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