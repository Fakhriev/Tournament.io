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
                _sprint.IncreaseSprintAmount(_parameters.SprintAmountIncreaseSpeed * Time.deltaTime);
                return this;
            }
        }
    }
}