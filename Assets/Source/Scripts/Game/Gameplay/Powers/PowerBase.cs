using Game.Gameplay.Abstracts;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers
{
    public abstract class PowerBase
    {
        protected DiContainer _container;
        protected GameObject _ownerGameObject;
        protected IPawnCharacter _ownerCharacter;

        [Inject]
        public PowerBase(DiContainer container, IPawnCharacter pawnCharacter)
        {
            _container = container;
            _ownerCharacter = pawnCharacter;
            _ownerGameObject = pawnCharacter.Mono.gameObject;
        }

        public abstract void Activate();

        public abstract void Deactivate();
    }
}