using Game.Gameplay.Abstracts;
using Game.Gameplay.Powers;
using Game.Gameplay.Powers.BehaviorComponents;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn
{
    public class PawnPower : MonoBehaviour, IPawnActivateObject, IPawnDeactivateObject
    {
        private DiContainer _container;
        private IPawnCharacter _character;
        private PowersDistributor _powersDistributor;

        private PowerBase _power;

        [Inject]
        private void Construct(DiContainer container, PowersDistributor powersDistributor)
        {
            _container = container;
            _powersDistributor = powersDistributor;
        }

        public void Activate()
        {
            _character ??= _container.Resolve<IPawnCharacter>();
            _power = _powersDistributor.InstantiatePower(_container, _character);
        }

        public void Deactivate()
        {
            _power.Deactivate();
        }
    }
}