using Game.Gameplay.Abstracts;
using Game.Gameplay.Powers.BehaviorComponents;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers
{
    public class SpikyShiledPower : PowerBase
    {
        private SpikyShield _spikyShild;

        public SpikyShiledPower(DiContainer container, IPawnCharacter pawnCharacter) : base(container, pawnCharacter)
        {

        }

        public override void Activate()
        {
            _spikyShild = _container.InstantiatePrefabForComponent<SpikyShield>(_ownerGameObject);
        }

        public override void Deactivate()
        {
            Object.Destroy(_spikyShild);
        }
    }
}