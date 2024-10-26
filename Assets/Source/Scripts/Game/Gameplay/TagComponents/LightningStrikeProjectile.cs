using Game.Gameplay.Abstracts;
using Game.Gameplay.InteractableObject;
using Game.Gameplay.Pawn.Collliding;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class LightningStrikeProjectile : MonoBehaviour, IHitSource
    {
        private Pool _pool;
        private DiContainer _container;

        private Rigidbody2D _rigidbody2D;
        private LightningStrikeProjectileParameters _parameters;
        private InteractableObjectInteractions _interactions;

        private IPawnCharacter _owner;
        private float _lifeTime;

        public IPawnCharacter Owner => _owner;

        [Inject]
        private void Construct(Pool pool, DiContainer container,
            LightningStrikeProjectileParameters parameters, Rigidbody2D rigidbody2D, InteractableObjectInteractions interactions)
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
            _interactions.OnInteract += TryToKill;
        }

        public void Activate(SpawnParameters spawnParameters)
        {
            _owner = spawnParameters.Owner;
            MonoBehaviour ownerMonoBehavior = _owner as MonoBehaviour;
            gameObject.name = $"{nameof(LightningStrikeProjectile)} - {ownerMonoBehavior.name}";

            transform.position = spawnParameters.SpawnPosition;
            transform.rotation = spawnParameters.SpawnRotation;

            _lifeTime = _parameters.LifeTime;
        }

        private void Update()
        {
            _lifeTime -= Time.deltaTime;

            if (_lifeTime <= 0f)
                Deactivate();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.MovePosition(transform.position + _parameters.MoveSpeed * Time.fixedDeltaTime * transform.up);
        }

        private void TryToKill(PawnBody body)
        {
            body.Hit(this);
            Deactivate();
        }

        private void Deactivate()
        {
            _pool.Despawn(this);
            gameObject.name = $"{nameof(LightningStrikeProjectile)}";
        }
    }

    [Serializable]
    public struct LightningStrikeProjectileParameters
    {
        [Space]
        public InteractableObjectPartsParameters InteractableObjectPartsParameters;

        [Space]
        public float MoveSpeed;
        public float LifeTime;
    }
}