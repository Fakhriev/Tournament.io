using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers
{
    public class ExceptionPower : PowerBase
    {
        public ExceptionPower(DiContainer container, GameObject pawnGameObject) : base(container, pawnGameObject)
        {

        }

        public override void Activate()
        {
            throw new PowerException();
        }

        public override void Deactivate()
        {
            throw new PowerException();
        }

        private class PowerException : Exception
        {

        }
    }
}