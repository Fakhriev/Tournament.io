using DG.Tweening;
using Game.Gameplay.InteractableObject;
using Game.Gameplay.Pawn.Collliding;
using Game.Gameplay.Utility;
using Redcode.Extensions;
using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Gameplay.TagComponents
{
    public partial class GoldCoin : MonoBehaviour
    {
        private Pool _pool;
        private DiContainer _container;

        private Rigidbody2D _rigidbody2D;
        private GoldCoinParameters _parameters;
        private InteractableObjectInteractions _interactions;

        private int _index;

        [Inject]
        private void Construct(Pool pool, DiContainer container,
            GoldCoinParameters parameters, Rigidbody2D rigidbody2D, InteractableObjectInteractions interactions)
        {
            _pool = pool;
            _container = container;
            _container.BindInstance(parameters.InteractableObjectPartsParameters);

            _parameters = parameters;
            _rigidbody2D = rigidbody2D;
            _interactions = interactions;
        }

        public void Initialize()
        {
            _interactions.OnInteract += CollectGoldCoin;
        }

        public void Activate(SpawnParameters spawnParameters)
        {
            _index = spawnParameters.Index;
            gameObject.name = gameObject.name.Replace(Constants.IndexPlace, _index.ToString());

            transform.position = spawnParameters.SpawnPosition;
            SpawnAnimation();
        }

        private void SpawnAnimation()
        {
            _rigidbody2D.DOMove(transform.position + (Random.insideUnitCircle * _parameters.SpawnRadius).InsertZ(), _parameters.SpawnAnimationDuration);
            transform.DOScale(_parameters.EndScale, _parameters.SpawnAnimationDuration).From(_parameters.BeginScale);
        }

        private void CollectGoldCoin(PawnBody body)
        {
            body.TakeGoldCoin(this);
            Deactivate();
        }

        private void Deactivate()
        {
            gameObject.name = gameObject.name.Replace(_index.ToString(), Constants.IndexPlace);
            _pool.Despawn(this);
        }
    }

    [Serializable]
    public struct GoldCoinParameters
    {
        [Space]
        public InteractableObjectPartsParameters InteractableObjectPartsParameters;

        [Space]
        public int GoldAmount;

        [Space]
        public float SpawnRadius;
        public float SpawnAnimationDuration;

        public float BeginScale;
        public float EndScale;
    }
}