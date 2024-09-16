using Game.Gameplay.Pawn.Collliding;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn
{
    public class PawnParts : MonoBehaviour, IInitializable
    {
        private DiContainer _container;
        private PawnPartsParameters _parameters;

        private PawnLegs _legs;
        private PawnBody _body;
        private PawnWeapon _weapon;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _parameters = _container.Resolve<PawnPartsParameters>();
            InstallPawnParts();
        }

        private void InstallPawnParts()
        {
            _legs = _container.InstantiatePrefabForComponent<PawnLegs>(_parameters.PawnLegs, transform);
            _body = _container.InstantiatePrefabForComponent<PawnBody>(_parameters.PawnBody, transform);
            _weapon = _container.InstantiatePrefabForComponent<PawnWeapon>(_parameters.PawnWeapon, transform);

            _legs.SetSortingOrder(_parameters.LegsSortingOrder);
            _body.SetSortingOrder(_parameters.BodySortingOrder);
            _weapon.SetSortingOrder(_parameters.WeaponSortingOrder);

            _container.BindInstance(_legs);
            _container.BindInstance(_body);
            _container.BindInstance(_weapon);
        }

        public void SetLayers(int value)
        {
            _legs.gameObject.layer = value;
            _body.gameObject.layer = value;
            _weapon.gameObject.layer = value;
        }
    }

    [Serializable]
    public struct PawnPartsParameters
    {
        public PawnLegs PawnLegs;
        public PawnBody PawnBody;
        public PawnWeapon PawnWeapon;

        public int LegsSortingOrder;
        public int BodySortingOrder;
        public int WeaponSortingOrder;
    }
}