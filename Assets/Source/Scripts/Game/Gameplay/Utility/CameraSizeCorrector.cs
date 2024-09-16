using Assets.Source.Scripts.Game.Gameplay.Stage;
using DG.Tweening;
using Game.Gameplay.Pawn.Size;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Utility
{
    public class CameraSizeCorrector : MonoBehaviour, IRestartObject
    {
        private Camera _mainCamera;
        private DiContainer _container;
        private CameraSizeCorrectorParameters _parameters;

        private PawnSize _playerPawnSize;

        private float _orthographicSize;
        private Tween _orthoSizeIncrease;

        [Inject]
        private void Construct(DiContainer container, Camera mainCamera, CameraSizeCorrectorParameters cameraSizeCorrectorParameters)
        {
            _container = container;
            _mainCamera = mainCamera;
            _parameters = cameraSizeCorrectorParameters;
        }

        private void Start()
        {
            _playerPawnSize = _container.Resolve<PawnSize>();

            SetCameraStartSize();

            _playerPawnSize.OnSizeIncrease += UpdateCameraOrthograpicSize;
        }

        private void SetCameraStartSize()
        {
            if (_orthoSizeIncrease != null)
            {
                _orthoSizeIncrease.Complete();
                _orthoSizeIncrease = null;
            }

            _orthographicSize = _parameters.StartOrtographicSize;
            _mainCamera.orthographicSize = _orthographicSize;
        }

        private void UpdateCameraOrthograpicSize(float playerSize)
        {
            if (_orthoSizeIncrease != null)
            {
                _orthoSizeIncrease.Complete();
            }

            _orthographicSize += _parameters.IncreaseSizeValue;
            _orthoSizeIncrease = _mainCamera.DOOrthoSize(_orthographicSize, _parameters.SizeIncreaseAnimationDuration).OnComplete(() => _orthoSizeIncrease = null);
        }

        public void Restart()
        {
            SetCameraStartSize();
        }
    }

    [Serializable]
    public struct CameraSizeCorrectorParameters
    {
        public float StartOrtographicSize;
        public float IncreaseSizeValue;
        public float SizeIncreaseAnimationDuration;
    }
}