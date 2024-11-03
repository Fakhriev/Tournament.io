using UnityEngine;
using Zenject;

namespace Game.Gameplay.StateServices
{
    public class GameRestarter : MonoBehaviour
    {
        private IPreRestartObject[] _preRestartObjects;
        private IRestartObject[] _restartObjects;

        [Inject]
        private void Construct(IPreRestartObject[] preRestartObjects, IRestartObject[] restartObjects)
        {
            _preRestartObjects = preRestartObjects;
            _restartObjects = restartObjects;
        }

        public void RestartGame()
        {
            foreach (var preRestartObject in _preRestartObjects)
            {
                preRestartObject.PreRestart();
            }

            foreach (var restartObject in _restartObjects)
            {
                restartObject.Restart();
            }
        }
    }

    public interface IPreRestartObject
    {
        public void PreRestart();
    }

    public interface IRestartObject
    {
        public void Restart();
    }
}