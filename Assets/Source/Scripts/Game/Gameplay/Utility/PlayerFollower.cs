using Game.Gameplay.TagComponents;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Utility
{
    public class PlayerFollower : MonoBehaviour
    {
        private DiContainer _container;

        private Transform _playerTransform;
        private Vector3 _positionOffset;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _container = diContainer;
        }

        private void Start()
        {
            _playerTransform = _container.Resolve<Player>().transform;
            _positionOffset = transform.position - _playerTransform.position;
        }

        private void LateUpdate()
        {
            transform.position = _playerTransform.position + _positionOffset;
        }
    }
}