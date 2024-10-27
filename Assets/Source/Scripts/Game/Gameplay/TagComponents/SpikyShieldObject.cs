using Game.Gameplay.Abstracts;
using Game.Gameplay.InteractableObject;
using Game.Gameplay.Pawn.Collliding;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class SpikyShieldObject : MonoBehaviour, IHitSource
    {
        private Pool _pool;
        private DiContainer _container;

        private Rigidbody2D _rigidbody2D;
        private SpikyShieldObjectParameters _parameters;
        private InteractableObjectInteractions _interactions;

        private IPawnCharacter _owner;
        private Transform _ownerTransform;

        private float _lifeTime;

        public IPawnCharacter Owner => _owner;

        [Inject]
        private void Construct(Pool pool, DiContainer container,
            SpikyShieldObjectParameters parameters, Rigidbody2D rigidbody2D, InteractableObjectInteractions interactions)
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
            _interactions.OnInteractToWeapon += CollideWithWeapon;
            _interactions.OnInteractToBody += CollideWithBody;
        }

        public void Activate(SpawnParameters spawnParameters)
        {
            _owner = spawnParameters.Owner;
            MonoBehaviour ownerMonoBehavior = _owner as MonoBehaviour;

            _ownerTransform = ownerMonoBehavior.transform;
            gameObject.name = $"{nameof(SpikyShieldObject)} - {ownerMonoBehavior.name}";

            transform.localScale = Vector3.one * _parameters.Scale;
            _lifeTime = _parameters.LifeTime;
        }

        private void Update()
        {
            _lifeTime -= Time.deltaTime;

            if (_lifeTime <= 0f)
                Deactivate();
        }

        private void LateUpdate()
        {
            UpdatePositionAndRotation();
        }

        private void UpdatePositionAndRotation()
        {
            transform.position = _ownerTransform.position;
            transform.rotation = _ownerTransform.rotation;
        }

        private void CollideWithWeapon(PawnWeapon weapon)
        {
            if (weapon.Owner.Equals(_owner))
                return;

            PawnBody body = weapon.Owner.PawnContainer.Resolve<PawnBody>();
            body.Hit(this);
            Deactivate();
        }

        private void CollideWithBody(PawnBody body)
        {
            if (body.Owner.Equals(_owner))
                return;

            body.Hit(this);
            Deactivate();
        }

        private void Deactivate()
        {
            _pool.Despawn(this);
            gameObject.name = $"{nameof(SpikyShieldObject)}";
        }
    }

    [Serializable]
    public struct SpikyShieldObjectParameters
    {
        [Space]
        public InteractableObjectPartsParameters InteractableObjectPartsParameters;

        [Space]
        public float LifeTime;
        public float Scale;
    }
}