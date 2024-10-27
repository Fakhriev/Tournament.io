using Game.Gameplay.Abstracts;
using Game.Gameplay.TagComponents;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers
{
    public class PowersDistributor : MonoBehaviour
    {
        private DiContainer _container;
        private PowersDistributorParameters _parameters;

        private DiContainer _pawnContainer;
        private IPawnCharacter _pawnCharacter;

        [Inject]
        private void Construct(DiContainer container, PowersDistributorParameters parameters)
        {
            _container = container;
            _parameters = parameters;
        }

        public PowerBase GetPower(DiContainer pawnContainer, IPawnCharacter pawnCharacter)
        {
            _pawnContainer = pawnContainer;
            _pawnCharacter = pawnCharacter;

            PowerBase power = new ExceptionPower(_container, _pawnCharacter);

            if (_pawnCharacter is Player)
                power = GetPlayerPower();

            if (_pawnCharacter is Enemy)
                power = GetEnemyPower();

            if (_pawnCharacter is Boss)
                power = GetBossPower();

            return power;
        }

        private PowerBase GetPlayerPower()
        {
            return _container.Instantiate<LightningStrikePower>(new object[] { _pawnContainer, _pawnCharacter});
        }

        private PowerBase GetEnemyPower()
        {
            return _container.Instantiate<EmptyPower>(new object[] { _pawnContainer, _pawnCharacter });
        }

        private PowerBase GetBossPower()
        {
            return _container.Instantiate<EmptyPower>(new object[] { _pawnContainer, _pawnCharacter });
        }
    }

    [Serializable]
    public struct PowersDistributorParameters
    {

    }
}