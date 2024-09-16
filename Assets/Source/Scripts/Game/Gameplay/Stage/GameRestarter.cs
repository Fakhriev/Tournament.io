using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Game.Gameplay.Stage
{
    public class GameRestarter : MonoBehaviour
    {
        private IRestartObject[] _restartObjects;

        [Inject]
        private void Construct(IRestartObject[] restartObjects)
        {
            _restartObjects = restartObjects;
        }

        public void RestartGame()
        {
            foreach (var restartObject in _restartObjects)
            {
                restartObject.Restart();
            }
        }
    }

    public interface IRestartObject
    {
        public void Restart();
    }
}