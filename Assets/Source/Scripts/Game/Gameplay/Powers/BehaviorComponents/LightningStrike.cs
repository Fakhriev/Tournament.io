using Game.Gameplay.Abstracts;
using Game.Gameplay.TagComponents;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers.BehaviorComponents
{
    public partial class LightningStrike : MonoBehaviour
    {
        private DiContainer _container;
        private LightningStrikeProjectile.Pool _projectilesPool;
        private LightningStrikeParameters _parameters;

        private IPawnCharacter _character;
        private float _fireInterval;

        [Inject]
        private void Construct(DiContainer container, LightningStrikeProjectile.Pool projectilesPool,
            LightningStrikeParameters parameters)
        {
            _container = container;
            _projectilesPool = projectilesPool;
            _parameters = parameters;
        }

        private void Start()
        {
            _character = _container.Resolve<IPawnCharacter>();
            UpdateFireInterval();
        }

        private void UpdateFireInterval()
        {
            _fireInterval = _parameters.FireInterval;
        }

        private void Update()
        {
            _fireInterval -= Time.deltaTime;

            if (_fireInterval <= 0f)
                Shoot();
        }

        private void Shoot()
        {
            Vector3 spawnPosition = transform.position + transform.right * _parameters.SpawnForwardDelta;
            Quaternion spawnRotation = transform.rotation * Quaternion.AngleAxis(-90f, Vector3.forward);

            var projectileSpawnParameters = new LightningStrikeProjectile.SpawnParameters(_character, spawnPosition, spawnRotation);
            var projectile = _projectilesPool.Spawn(projectileSpawnParameters);

            UpdateFireInterval();
        }
    }

    [Serializable]
    public struct LightningStrikeParameters
    {
        public float FireInterval;
        public float SpawnForwardDelta;
    }
}