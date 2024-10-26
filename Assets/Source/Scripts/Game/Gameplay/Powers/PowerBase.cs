using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers
{
    public abstract class PowerBase
    {
        protected DiContainer _container;
        protected GameObject _pawnGameObject;

        [Inject]
        public PowerBase(DiContainer container, GameObject pawnGameObject)
        {
            _container = container;
            _pawnGameObject = pawnGameObject;
        }

        public abstract void Activate();

        public abstract void Deactivate();
    }
}