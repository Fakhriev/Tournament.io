using UnityEngine;

namespace Game.Gameplay.Powers
{
    public abstract class PowerBase
    {
        protected GameObject _pawnGameObject;

        public PowerBase(GameObject pawnGameObject)
        {
            _pawnGameObject = pawnGameObject;
        }

        public abstract void Activate();
    }
}