using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn.Movement
{
    public class PawnRotation : MonoBehaviour, IPawnActivateObject
    {
        private PawnMovement _movemenet;

        [Inject]
        private void Construct(PawnMovement movement)
        {
            _movemenet = movement;
        }

        private void LateUpdate()
        {
            Vector3 moveDirection = _movemenet.MoveDirection;
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        public void Activate()
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        }
    }
}