using Game.Gameplay.Abstracts;
using Game.Gameplay.TagComponents;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers.BehaviorComponents
{
    public class PowersDistributor : MonoBehaviour
    {
        private DiContainer _container;
        private PowersDistributorParameters _parameters;

        private DiContainer _pawnContainer;
        private GameObject _pawnGameObject;

        [Inject]
        private void Construct(DiContainer container, PowersDistributorParameters parameters)
        {
            _container = container;
            _parameters = parameters;
        }

        public PowerBase InstantiatePower(DiContainer pawnContainer, IPawnCharacter pawnCharacter)
        {
            _pawnContainer = pawnContainer;
            _pawnGameObject = pawnCharacter.PawnGameObject;

            PowerBase power = null;

            if (pawnCharacter is Player)
                power = InstantiatePlayerPower();

            if (pawnCharacter is Enemy)
                power = InstantiateEnemyPower();

            if (pawnCharacter is Boss)
                power = InstantiateBossPower();

            return power;
        }

        private PowerBase InstantiatePlayerPower()
        {
            return _pawnContainer.InstantiateComponent<AppleTrashThrowPower>(_pawnGameObject);
        }

        private PowerBase InstantiateEnemyPower()
        {
            return _pawnContainer.InstantiateComponent<EmptyPower>(_pawnGameObject);
        }

        private PowerBase InstantiateBossPower()
        {
            return _pawnContainer.InstantiateComponent<EmptyPower>(_pawnGameObject);
        }
    }

    [Serializable]
    public struct PowersDistributorParameters
    {

    }
}