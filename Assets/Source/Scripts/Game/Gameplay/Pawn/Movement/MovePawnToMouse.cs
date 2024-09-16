using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn.Movement
{
    [RequireComponent(typeof(PawnMovement))]
    public class MovePawnToMouse : MonoBehaviour
    {
        private Camera _mainCamera;
        private PawnMovement _movement;

        [Inject]
        private void Construct(Camera mainCamera, PawnMovement movement)
        {
            _mainCamera = mainCamera;
            _movement = movement;
        }

        private void Update()
        {
            FindTargetPosition();
        }

        private void FindTargetPosition()
        {
            if (Input.GetMouseButton(0) == false)
            {
                return;
            }

            _movement.MoveToPosition(_mainCamera.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}