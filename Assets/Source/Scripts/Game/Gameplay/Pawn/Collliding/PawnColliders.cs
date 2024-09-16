using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn.Collliding
{
    public class PawnColliders : MonoBehaviour
    {
        private PawnLegs _pawnLegs;
        private PawnBody _pawnBody;
        private PawnWeapon _pawnWeapon;

        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        private void Start()
        {
            _pawnLegs = _container.Resolve<PawnLegs>();
            _pawnBody = _container.Resolve<PawnBody>();
            _pawnWeapon = _container.Resolve<PawnWeapon>();

            _pawnWeapon.IgnoreCollisions(_pawnLegs);
            _pawnWeapon.IgnoreCollisions(_pawnBody);
        }
    }
}