using Game.Gameplay.Pawn.Movement;
using Game.Gameplay.Pawn.Size;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers.BehaviorComponents
{
    public class SprintIncreaseBySizePower : PowerBase
    {
        private SprintIncreaseBySizePowerParameters _parameters;

        private PawnSize _pawnSize;
        private float _actualSize;

        private PawnSprint _pawnSprint;
        private float _actualSprintSpeed;

        [Inject]
        private void Construct(SprintIncreaseBySizePowerParameters parameters)
        {
            _parameters = parameters;
        }

        private void Start()
        {
            _pawnSize = _container.Resolve<PawnSize>();
            _pawnSize.OnSizeIncrease += OnPawnSizeIncrease;
            _actualSize = _pawnSize.Value;

            _pawnSprint = _container.Resolve<PawnSprint>();
            _actualSprintSpeed = _container.Resolve<PawnSprintParameters>().SprintSpeed;
        }

        private void OnPawnSizeIncrease(float increasedSize)
        {
            float sizeFactor = increasedSize / _actualSize;
            _actualSize = increasedSize;

            _actualSprintSpeed += _actualSprintSpeed * (sizeFactor - 1f) * _parameters.SprintIncreaseFactor;
            _pawnSprint.SetNewSprintSpeed(_actualSprintSpeed);
        }
    }

    [Serializable]
    public struct SprintIncreaseBySizePowerParameters
    {
        public float SprintIncreaseFactor;
    }
}