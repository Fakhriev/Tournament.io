using Game.Gameplay.Abstracts;
using Game.Gameplay.Powers;
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
            _power = _powersDistributor.GetPower(_container, _character);
            _power.Activate();
        }

        public void Deactivate()
        {
            _power.Deactivate();
        }
    }
}