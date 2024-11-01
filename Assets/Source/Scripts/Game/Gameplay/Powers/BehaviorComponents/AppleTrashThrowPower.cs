using Game.Gameplay.Pawn.Collliding;
using Game.Gameplay.TagComponents;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers.BehaviorComponents
{
    public class AppleTrashThrowPower : PowerBase
    {
        private AppleTrashThrowPowerParameters _parameters;
        private AppleTrashProjectile.Pool _projectilesPool;

        private PawnBody _pawnBody;

        [Inject]
        private void Construct(AppleTrashThrowPowerParameters parameters, AppleTrashProjectile.Pool projectilesPool)
        {
            _parameters = parameters;
            _projectilesPool = projectilesPool;
        }

        private void Start()
        {
            _pawnBody = _container.Resolve<PawnBody>();
            _pawnBody.OnAppleEated += OnAppleEated;
        }

        private void OnAppleEated(Apple apple)
        {
            Quaternion firstSpawnRotation = transform.rotation;
            Vector3 firstSpawnPosition = transform.position + transform.up * _parameters.SpawnRightDelta;
            var firstAppleSpawnParameters = new AppleTrashProjectile.SpawnParameters(_character, firstSpawnPosition, firstSpawnRotation);

            Quaternion secondSpawnRotation = transform.rotation * Quaternion.AngleAxis(180f, Vector3.forward);
            Vector3 secondSpawnPosition = transform.position - transform.up * _parameters.SpawnRightDelta;
            var secondAppleSpawnParameters = new AppleTrashProjectile.SpawnParameters(_character, secondSpawnPosition, secondSpawnRotation);

            var firstApple = _projectilesPool.Spawn(firstAppleSpawnParameters);
            var secondApple = _projectilesPool.Spawn(secondAppleSpawnParameters);
        }

        private void OnDestroy()
        {
            _pawnBody.OnAppleEated -= OnAppleEated;
        }
    }

    [Serializable]
    public struct AppleTrashThrowPowerParameters
    {
        public float SpawnRightDelta;
    }
}