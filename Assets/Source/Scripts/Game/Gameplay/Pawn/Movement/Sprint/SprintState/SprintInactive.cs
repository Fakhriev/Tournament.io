using UnityEngine;

namespace Game.Gameplay.Pawn.Movement
{
    public partial class PawnSprint : MonoBehaviour
    {
        public class SprintInactive : ISprintState
        {
            private PawnSprint _sprint;
            private PawnMovement _movement;
            private PawnSprintParameters _parameters;

            public SprintInactive(PawnSprint sprint, PawnMovement movement, ref PawnSprintParameters parameters)
            {
                _sprint = sprint;
                _movement = movement;
                _parameters = parameters;

                _movement.SetOriginalMoveSpeed();
            }

            public ISprintState Execute()
            {
                _sprint._sprintAmount += _parameters.SprintAmountIncreaseSpeed * Time.deltaTime;
                _sprint._sprintAmount = Mathf.Clamp(_sprint._sprintAmount, 0f, _parameters.SprintMaxAmount);

                return this;
            }
        }
    }
}