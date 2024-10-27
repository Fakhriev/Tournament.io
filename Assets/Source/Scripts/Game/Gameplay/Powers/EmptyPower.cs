using Game.Gameplay.Abstracts;
using Zenject;

namespace Game.Gameplay.Powers
{
    public class EmptyPower : PowerBase
    {
        public EmptyPower(DiContainer container, IPawnCharacter pawnCharacter) : base(container, pawnCharacter)
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