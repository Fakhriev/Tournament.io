using Game.Gameplay.Pawn.Collliding;
using Game.Gameplay.Pawn.Movement;
using Game.Gameplay.TagComponents;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers.BehaviorComponents
{
    public class SprintRestoreByArmorFragmentsPower : PowerBase
    {
        private SprintRestoreByArmorFragmentsPowerParameters _parameters;

        private PawnSprint _pawnSprint;
        private PawnBody _pawnBody;

        [Inject]
        private void Construct(SprintRestoreByArmorFragmentsPowerParameters parameters)
        {
            _parameters = parameters;
        }

        private void Start()
        {
            _pawnBody = _container.Resolve<PawnBody>();
            _pawnBody.OnArmored += OnArmored;

            _pawnSprint = _container.Resolve<PawnSprint>();
        }

        private void OnArmored(ArmorFragment armorFragment)
        {
            _pawnSprint.IncreaseSprintAmount(_parameters.SprintRestoreAmount);
        }

        private void OnDestroy()
        {
            _pawnBody.OnArmored -= OnArmored;
        }
    }

    [Serializable]
    public struct SprintRestoreByArmorFragmentsPowerParameters
    {
        public float SprintRestoreAmount;
    }
}