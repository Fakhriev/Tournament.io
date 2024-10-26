using Game.Gameplay.TagComponents;
using Game.Gameplay.Utility.Extensions;
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
        private GameObject _pawnGameObject;

        [Inject]
        private void Construct(DiContainer container, PowersDistributorParameters parameters)
        {
            _container = container;
            _parameters = parameters;
        }

        public PowerBase GetPower(DiContainer pawnContainer, GameObject pawnGameObject)
        {
            _pawnContainer = pawnContainer;
            _pawnGameObject = pawnGameObject;
            PowerBase power = new ExceptionPower(_container, _pawnGameObject);

            if (_pawnGameObject.HasComponent<Player>())
                power = GetPlayerPower();

            if(_pawnGameObject.HasComponent<Enemy>())
                power = GetEnemyPower();

            if (_pawnGameObject.HasComponent<Boss>())
                power = GetBossPower();

            return power;
        }

        private PowerBase GetPlayerPower()
        {
            return _container.Instantiate<LightningStrikePower>(new object[] { _pawnContainer, _pawnGameObject});
        }

        private PowerBase GetEnemyPower()
        {
            return _container.Instantiate<EmptyPower>(new object[] { _pawnContainer, _pawnGameObject });
        }

        private PowerBase GetBossPower()
        {
            return _container.Instantiate<EmptyPower>(new object[] { _pawnContainer, _pawnGameObject });
        }
    }

    [Serializable]
    public struct PowersDistributorParameters
    {

    }
}