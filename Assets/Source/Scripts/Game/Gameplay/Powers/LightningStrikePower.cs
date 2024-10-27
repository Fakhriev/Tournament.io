using Game.Gameplay.Abstracts;
using Game.Gameplay.Powers.BehaviorComponents;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers
{
    public class LightningStrikePower : PowerBase
    {
        private LightningStrike _lightningStrike;

        public LightningStrikePower(DiContainer container, IPawnCharacter pawnCharacter) : base(container, pawnCharacter)
        {

        }

        public override void Activate()
        {
            _lightningStrike = _container.InstantiateComponent<LightningStrike>(_ownerGameObject);
        }

        public override void Deactivate()
        {
            Object.Destroy(_lightningStrike);
        }
    }
}