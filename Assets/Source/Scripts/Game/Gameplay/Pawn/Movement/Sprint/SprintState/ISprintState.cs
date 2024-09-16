using UnityEngine;

namespace Game.Gameplay.Pawn.Movement
{
    public partial class PawnSprint : MonoBehaviour
    {
        public interface ISprintState
        {
            public ISprintState Execute();
        }
    }
}