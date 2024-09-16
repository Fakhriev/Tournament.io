using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn.Movement
{
    public class PawnMovement : MonoBehaviour, IPawnActivateObject
    {
        private Rigidbody2D _rigidbody2D;
        public PawnMovementParameters _parameters;

        private float _moveSpeed;

        public Vector3 MoveDirection { get; private set; }

        [Inject]
        private void Construct(Rigidbody2D rigidbody2D, PawnMovementParameters parameters)
        {
            _rigidbody2D = rigidbody2D;
            _parameters = parameters;
            _moveSpeed = parameters.MoveSpeed;
        }

        public void Activate()
        {
            MoveDirection = UnityEngine.Random.insideUnitCircle.normalized;
        }

        public void MoveToPosition(Vector2 position)
        {
            MoveDirection = (position - _rigidbody2D.position).normalized;
            TryMoveToDirection();
        }

        public void MoveToDirection(Vector2 direction)
        {
            MoveDirection = direction.normalized;
            TryMoveToDirection();
        }

        private void TryMoveToDirection()
        {
            if (MoveDirection.Equals(Vector3.zero))
                return;

            _rigidbody2D.MovePosition(_rigidbody2D.transform.position + MoveDirection * _moveSpeed * Time.fixedDeltaTime);
        }

        public void SetNewMoveSpeed(float newMoveSpeed)
        {
            _moveSpeed = newMoveSpeed;
        }

        public void SetOriginalMoveSpeed()
        {
            _moveSpeed = _parameters.MoveSpeed;
        }
    }

    [Serializable]
    public struct PawnMovementParameters
    {
        public float MoveSpeed;
    }
}