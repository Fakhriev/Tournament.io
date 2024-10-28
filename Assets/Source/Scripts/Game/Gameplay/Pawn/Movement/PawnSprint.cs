using Game.Gameplay.Pawn.Collliding;
using Game.Gameplay.Pawn.Movement.Sprint.SprintControll;
using Game.Gameplay.TagComponents;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn.Movement
{
    public partial class PawnSprint : MonoBehaviour, IPawnActivateObject
    {
        private DiContainer _container;
        private PawnMovement _movement;
        private PawnSprintParameters _parameters;

        private PawnBody _body;

        private float _sprintSpeed;
        private float _sprintAmount;

        private ISprintState _sprintState;
        private ISprintController _sprintController;

        public float SprintPercents => _sprintAmount / _parameters.SprintMaxAmount;
        public bool IsActive => _sprintState is SprintActive;

        [Inject]
        private void Construct(DiContainer container, PawnMovement movement, PawnSprintParameters parameters)
        {
            _container = container;
            _movement = movement;
            _parameters = parameters;

        }

        private void Start()
        {
            _body = _container.Resolve<PawnBody>();
            _body.OnAppleEated += RestoreSprintAmount;

            _sprintController = _container.Resolve<ISprintController>();
            _sprintController.OnSprintStateSwitched += SetSprintState;

            _sprintState = new SprintInactive(this, _movement, ref _parameters);
        }

        public void Activate()
        {
            _sprintSpeed = _parameters.SprintSpeed;
            _sprintAmount = _parameters.SprintMaxAmount;

            _sprintState = new SprintInactive(this, _movement, ref _parameters);
            _movement.SetOriginalMoveSpeed();
        }

        private void Update()
        {
            _sprintState = _sprintState.Execute();
        }

        private void RestoreSprintAmount(Apple apple)
        {
            IncreaseSprintAmount(apple.RestoreAmount);
        }

        private void SetSprintState(bool activeState)
        {
            if (activeState == IsActive)
                return;

            if (activeState)
                _sprintState = new SprintActive(this, _movement, ref _parameters);
            else
                _sprintState = new SprintInactive(this, _movement, ref _parameters);
        }

        public void IncreaseSprintAmount(float value)
        {
            _sprintAmount += value;
            _sprintAmount = Mathf.Clamp(_sprintAmount, 0f, _parameters.SprintMaxAmount);
        }

        public void SetNewSprintSpeed(float value)
        {
            _sprintSpeed = value;

            if (IsActive)
                SetSprintSpeedToMovement();
        }

        private void SetSprintSpeedToMovement()
        {
            _movement.SetNewMoveSpeed(_sprintSpeed);
        }
    }

    [Serializable]
    public struct PawnSprintParameters
    {
        public float SprintSpeed;
        public float SprintMaxAmount;

        [Space]
        public float SprintAmountIncreaseSpeed;
        public float SprintAmountDecreaseSpeed;
    }
}