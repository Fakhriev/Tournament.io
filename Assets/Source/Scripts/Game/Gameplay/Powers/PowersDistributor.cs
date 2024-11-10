using Extensions;
using Game.Gameplay.Abstracts;
using Game.Gameplay.TagComponents;
using Redcode.Extensions;
using Services;
using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers.BehaviorComponents
{
    public class PowersDistributor : MonoBehaviour, IInitializable
    {
        private DiContainer _container;
        private PowersDistributorParameters _parameters;

        private DiContainer _pawnContainer;
        private GameObject _pawnGameObject;

        private PowersService _powersService;
        private Type[] _powersTypes;

        [Inject]
        private void Construct(DiContainer container, PowersDistributorParameters parameters,
            PowersService powersService)
        {
            _container = container;
            _parameters = parameters;
            _powersService = powersService;
        }

        public void Initialize()
        {
            _powersTypes = typeof(PowerBase).GetDerivedTypes().ToArray();
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
            var playerPowerType = _powersTypes.First(p => p.Name.Equals(_powersService.GetEquiped().identifier));
            return _pawnContainer.InstantiateComponent(playerPowerType, _pawnGameObject) as PowerBase;
        }

        private PowerBase InstantiateEnemyPower()
        {
            var enemyPowerType = _powersTypes.GetRandomElement();
            return _pawnContainer.InstantiateComponent(enemyPowerType, _pawnGameObject) as PowerBase;
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