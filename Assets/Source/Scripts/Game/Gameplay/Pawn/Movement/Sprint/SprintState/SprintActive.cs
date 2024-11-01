using Redcode.Extensions;
using UnityEngine;

namespace Game.Gameplay.Pawn.Movement
{
    public partial class PawnSprint : MonoBehaviour
    {
        public class SprintActive : ISprintState
        {
            private PawnSprint _sprint;
            private PawnMovement _movement;
            private PawnSprintParameters _parameters;

            public SprintActive(PawnSprint sprint, PawnMovement movement, ref PawnSprintParameters parameters)
            {
                _sprint = sprint;
                _movement = movement;
                _parameters = parameters;

                _sprint.SetSprintSpeedToMovement();
            }

            public ISprintState Execute()
            {
                if (IsSprintAmountEmpty())
                {
                    return new SprintInactive(_sprint, _movement, ref _parameters);
                }

                _sprint.IncreaseSprintAmount(-1f * _parameters.SprintAmountDecreaseSpeed * Time.deltaTime);
                return this;
            }

            private bool IsSprintAmountEmpty()
            {
                return _sprint._sprintAmount.Approximately(0f);
            }
        }
    }
}