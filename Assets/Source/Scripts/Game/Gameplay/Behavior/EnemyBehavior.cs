using Game.Gameplay.Pawn.Movement;
using Game.Gameplay.Pawn.Movement.Sprint.SprintControll;
using Game.Gameplay.TagComponents;
using Redcode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Gameplay.Behavior
{
    public class EnemyBehavior : MonoBehaviour
    {
        private EnemyBehaviorParameters _parameters;

        private Apple.Pool _applesPool;
        private ArmorFragment.Pool _armorFragmentsPool;

        private BehaviorPoints _points;
        private PawnMovement _movement;

        private PawnSprint _sprint;
        private ManualSprintController _sprintController;

        private Vector3 _targetPosition;

        private Vector3 Position => _movement.transform.position;

        [Inject]
        private void Construct(EnemyBehaviorParameters parameters, 
            ArmorFragment.Pool armorFragmentsPool, Apple.Pool applesPool,
            BehaviorPoints points, PawnMovement movement, 
            PawnSprint sprint, ISprintController sprintController)
        {
            _parameters = parameters;

            _applesPool = applesPool;
            _armorFragmentsPool = armorFragmentsPool;

            _sprint = sprint;
            _sprintController = sprintController as ManualSprintController;

            _points = points;
            _movement = movement;
        }

        private void Start()
        {
            SetTargetPositionFromBehaviorPoints();
        }

        private void Update()
        {
            TryToSetTargetPositionFromInteractableObject();

            _movement.MoveToPosition(_targetPosition);

            TrySetTargetPositionFromBehaviorPoints();
        }

        private void TryToSetTargetPositionFromInteractableObject()
        {
            if (TryFindClosestGameObject(_armorFragmentsPool.ActiveArmorFragments, _parameters.ArmorFragmentFindSqrRadius, out var armorFragment))
            {
                if (_sprint.IsActive == false && _sprint.SprintPercents > _parameters.MinimalSprintPercentsToSprint)
                {
                    _sprintController.ActivateSprint();
                }

                _targetPosition = armorFragment.transform.position;
            }
            else
            {
                if (_sprint.IsActive && _sprint.SprintPercents < _parameters.SprintSaveThresholdPercents)
                    _sprintController.DeactivateSprint();

                if (_sprint.SprintPercents <= _parameters.MinimalSprintPercentsToFindApples && 
                    TryFindClosestGameObject(_applesPool.ActiveApples, _parameters.AppleFindSqrRadius, out var apple))
                {
                    _targetPosition = apple.transform.position;
                }
            }
        }

        private bool TryFindClosestGameObject(IEnumerable<MonoBehaviour> list, float findRadius, out MonoBehaviour gameObject)
        {
            gameObject = null;
            float minimalRange = float.MaxValue;

            foreach (var gObject in list)
            {
                float sqrDistance = Vector3.SqrMagnitude(gObject.transform.position - Position);

                if (sqrDistance <= findRadius && sqrDistance < minimalRange)
                {
                    minimalRange = sqrDistance;
                    gameObject = gObject;
                }
            }

            return gameObject != null;
        }

        private void TrySetTargetPositionFromBehaviorPoints()
        {
            if (Vector3.SqrMagnitude(_targetPosition - Position) < _parameters.MinimalTargetPointApproachSqrDistance)
            {
                SetTargetPositionFromBehaviorPoints();
            }
        }

        private void SetTargetPositionFromBehaviorPoints()
        {
            Transform randomPoint = _points.Points.Where(
                p => Vector3.SqrMagnitude(p.transform.position - Position) >= _parameters.MinimalTargetPointFindSqrDistance
                && Vector3.SqrMagnitude(p.transform.position - Position) <= _parameters.MaximalTargetPointFindSqrDistance)
                .GetRandomElement();

            if (randomPoint == false)
                randomPoint = _points.Points.GetRandomElement();

            _targetPosition = randomPoint.position + Random.insideUnitCircle.InsertZ() * _parameters.TargetPositionFindRadius;
        }

        [ContextMenu("Activate Sprint")]
        private void ActivateSprint()
        {
            _sprintController.ActivateSprint();
        }
    }

    [Serializable]
    public struct EnemyBehaviorParameters
    {
        public float MinimalTargetPointFindSqrDistance;
        public float MaximalTargetPointFindSqrDistance;
        public float MinimalTargetPointApproachSqrDistance;

        [Space]
        public float TargetPositionFindRadius;

        [Space]
        public float ArmorFragmentFindSqrRadius;
        public float AppleFindSqrRadius;

        [Space]
        public float MinimalSprintPercentsToSprint;
        public float MinimalSprintPercentsToFindApples;
        public float SprintSaveThresholdPercents;
    }
}