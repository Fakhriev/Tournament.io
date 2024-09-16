using System;
using UnityEngine;

namespace Game.Gameplay.Pawn.Movement.Sprint.SprintControll
{
    public class PlayerKeyboardSprintController : MonoBehaviour, ISprintController
    {
        public event Action<bool> OnSprintStateSwitched;

        private void Update()
        {
            if (IsSprintButtonPressed())
            {
                OnSprintStateSwitched?.Invoke(true);
            }

            if (IsSprintButtonUnpressed())
            {
                OnSprintStateSwitched?.Invoke(false);
            }
        }

        private bool IsSprintButtonPressed()
        {
            return Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Space);
        }

        private bool IsSprintButtonUnpressed()
        {
            return Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.Space);
        }
    }
}