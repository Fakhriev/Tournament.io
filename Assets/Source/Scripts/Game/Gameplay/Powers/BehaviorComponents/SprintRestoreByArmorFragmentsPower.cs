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

        [Inject]
        private void Construct(SprintRestoreByArmorFragmentsPowerParameters parameters)
        {
            _parameters = parameters;
        }

        private void Start()
        {
            _pawnSprint = _container.Resolve<PawnSprint>();

            PawnBody pawnBody = _container.Resolve<PawnBody>();
            pawnBody.OnArmored += OnArmored;
        }

        private void OnArmored(ArmorFragment armorFragment)
        {
            _pawnSprint.IncreaseSprintAmount(_parameters.SprintRestoreAmount);
        }
    }

    [Serializable]
    public struct SprintRestoreByArmorFragmentsPowerParameters
    {
        [Space]
        public float SprintRestoreAmount;
    }
}