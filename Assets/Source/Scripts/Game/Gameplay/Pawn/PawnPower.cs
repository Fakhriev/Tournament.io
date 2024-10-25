using Game.Gameplay.Powers;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn
{
    public class PawnPower : MonoBehaviour, IPawnActivateObject
    {
        private PowersDistributor _powersDistributor;

        private PowerBase _power;

        [Inject]
        private void Construct(PowersDistributor powersDistributor)
        {
            _powersDistributor = powersDistributor;
        }

        public void Activate()
        {
            _power = _powersDistributor.GetPower(this);
            _power.Activate();
        }
    }
}