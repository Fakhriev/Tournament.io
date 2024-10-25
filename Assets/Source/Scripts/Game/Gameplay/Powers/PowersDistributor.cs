using Game.Gameplay.Pawn;
using Game.Gameplay.TagComponents;
using Game.Gameplay.Utility.Extensions;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers
{
    public class PowersDistributor : MonoBehaviour
    {
        private PowersDistributorParameters _parameters;
        private GameObject _pawnGameObject;

        [Inject]
        private void Construct(PowersDistributorParameters parameters)
        {
            _parameters = parameters;
        }

        public PowerBase GetPower(PawnPower pawnPower)
        {
            _pawnGameObject = pawnPower.gameObject;

            if (_pawnGameObject.HasComponent<Player>())
                return GetPlayerPower();

            if(_pawnGameObject.HasComponent<Enemy>())
                return GetEnemyPower();

            if (_pawnGameObject.HasComponent<Boss>())
                return GetBossPower();

            throw new Exception();
        }

        private PowerBase GetPlayerPower()
        {
            return new EmptyPower(_pawnGameObject);
        }

        private PowerBase GetEnemyPower()
        {
            return new EmptyPower(_pawnGameObject);
        }

        private PowerBase GetBossPower()
        {
            return new EmptyPower(_pawnGameObject);
        }
    }

    [Serializable]
    public struct PowersDistributorParameters
    {

    }
}