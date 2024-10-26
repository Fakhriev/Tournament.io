using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers
{
    public class EmptyPower : PowerBase
    {
        public EmptyPower(DiContainer container, GameObject pawnGameObject) : base(container, pawnGameObject)
        {

        }

        public override void Activate()
        {

        }

        public override void Deactivate()
        {

        }
    }
}