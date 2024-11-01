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
        private Tween _sizeIncrease;

        public Action<float> OnSizeIncrease;

        public float Value => _size;

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
            _sizeIncrease?.Complete();

            _size += _parameters.IncreaseSizeByArmor;
            _sizeIncrease = transform.DOScale(_size, _parameters.IncreaseSizeAnimationDuration).OnComplete(() => _sizeIncrease = null);

            OnSizeIncrease?.Invoke(_size);
        }
    }

    [Serializable]
    public struct PawnSizeParameters
    {
        public float StartSize;

        [Space]
        public float IncreaseSizeByArmor;
        public float IncreaseSizeAnimationDuration;
    }
}