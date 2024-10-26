using Game.Gameplay.Powers.BehaviorComponents;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers
{
    public class LightningStrikePower : PowerBase
    {
        private LightningStrike _lightningStrikeComponent;

        public LightningStrikePower(DiContainer container, GameObject pawnGameObject) : base(container, pawnGameObject)
        {

        }

        public override void Activate()
        {
            _lightningStrikeComponent = _container.InstantiateComponent<LightningStrike>(_pawnGameObject);
        }

        public override void Deactivate()
        {
            Object.Destroy(_lightningStrikeComponent);
        }
    }
}