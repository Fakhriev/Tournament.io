using Game.Gameplay.Pawn.Movement;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI
{
    public class SprintBar : MonoBehaviour
    {
        [SerializeField] 
        private Image _progressImage;

        private DiContainer _container;
        private PawnSprint _playerPawnSprint;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        private void Start()
        {
            _playerPawnSprint = _container.Resolve<PawnSprint>();
        }

        private void LateUpdate()
        {
            _progressImage.fillAmount = _playerPawnSprint.SprintPercents;
        }
    }
}