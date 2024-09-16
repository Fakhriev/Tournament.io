using System;

namespace Game.Gameplay.Pawn.Movement.Sprint.SprintControll
{
    public interface ISprintController
    {
        public event Action<bool> OnSprintStateSwitched;
    }
}