using Game.Gameplay.Abstracts;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Powers
{
    public abstract class PowerBase : MonoBehaviour
    {
        protected DiContainer _container;
        protected IPawnCharacter _character;

        [Inject]
        private void Construct(DiContainer container, IPawnCharacter pawnCharacter)
        {
            _container = container;
            _character = pawnCharacter;
        }

        public void Deactivate()
        {
            Destroy(this);
        }
    }
}