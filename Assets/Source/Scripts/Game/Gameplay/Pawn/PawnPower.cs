using Game.Gameplay.Powers;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn
{
    public class PawnPower : MonoBehaviour, IPawnActivateObject, IPawnDeactivateObject
    {
        private DiContainer _container;
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
            _power = _powersDistributor.GetPower(_container, gameObject);
            _power.Activate();
        }

        public void Deactivate()
        {
            _power.Deactivate();
        }
    }
}