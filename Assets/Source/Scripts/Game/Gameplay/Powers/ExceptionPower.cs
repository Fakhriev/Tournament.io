using Game.Gameplay.Abstracts;
using System;
using Zenject;

namespace Game.Gameplay.Powers
{
    public class ExceptionPower : PowerBase
    {
        public ExceptionPower(DiContainer container, IPawnCharacter pawnCharacter) : base(container, pawnCharacter)
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