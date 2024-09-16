using System;
using UnityEngine;

namespace Game.Gameplay.Pawn.Movement.Sprint.SprintControll
{
    public class ManualSprintController : ISprintController
    {
        public event Action<bool> OnSprintStateSwitched;

        public void ActivateSprint()
        {
            OnSprintStateSwitched?.Invoke(true);
        }

        public void DeactivateSprint()
        {
            OnSprintStateSwitched?.Invoke(false);
        }
    }
}