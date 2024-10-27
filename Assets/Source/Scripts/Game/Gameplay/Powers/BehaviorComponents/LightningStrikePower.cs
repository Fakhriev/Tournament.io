using Game.Gameplay.TagComponents;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers.BehaviorComponents
{
    public class LightningStrikePower : PowerBase
    {
        private LightningStrikePowerParameters _parameters;
        private LightningStrikeProjectile.Pool _projectilesPool;

        private float _fireInterval;

        [Inject]
        private void Construct(LightningStrikePowerParameters parameters, LightningStrikeProjectile.Pool projectilesPool)
        {
            _parameters = parameters;
            _projectilesPool = projectilesPool;
        }

        private void Start()
        {
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
    public struct LightningStrikePowerParameters
    {
        public float FireInterval;
        public float SpawnForwardDelta;
    }
}