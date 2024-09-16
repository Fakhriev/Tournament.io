using DG.Tweening;
using Game.Gameplay.Pawn.Collliding;
using Game.Gameplay.TagComponents;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn.Size
{
    public class PawnSize : MonoBehaviour, IPawnActivateObject
    {
        private DiContainer _container;
        private PawnSizeParameters _parameters;

        private PawnBody _body;

        private float _size;
        private Tween _scaleIncrease;

        public Action<float> OnSizeIncrease;

        [Inject]
        private void Construct(DiContainer container, PawnSizeParameters parameters)
        {
            _container = container;
            _parameters = parameters;
        }

        private void Start()
        {
            _body = _container.Resolve<PawnBody>();
            _body.OnArmored += IncreaseSize;
        }

        public void Activate()
        {
            _size = _parameters.StartSize;
            transform.localScale = new Vector3(_size, _size, 1f);
        }

        private void IncreaseSize(ArmorFragment armorFragment)
        {
            if(_scaleIncrease != null)
            {
                _scaleIncrease.Complete();
            }

            _size += _parameters.ArmoringSize;
            _scaleIncrease = transform.DOScale(_size, _parameters.ArmoringAnimationDuration).OnComplete(() => _scaleIncrease = null);
            OnSizeIncrease?.Invoke(_size);
        }
    }

    [Serializable]
    public struct PawnSizeParameters
    {
        public float StartSize;
        public float ArmoringSize;
        public float ArmoringAnimationDuration;
    }
}