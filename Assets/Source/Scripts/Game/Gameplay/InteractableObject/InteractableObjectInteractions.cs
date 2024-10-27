using Game.Gameplay.Pawn.Collliding;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.InteractableObject
{
    public class InteractableObjectInteractions : MonoBehaviour
    {
        public Action<PawnWeapon> OnInteractToWeapon;
        public Action<PawnBody> OnInteractToBody;

        private DiContainer _container;
        private InteractableObjectBody _body;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        private void Start()
        {
            _body = _container.Resolve<InteractableObjectBody>();
            _body.OnWeaponCollide += InteractToWeapon;
            _body.OnBodyCollide += InteractToBody;
        }

        private void InteractToWeapon(PawnWeapon pawnWeapon)
        {
            OnInteractToWeapon?.Invoke(pawnWeapon);
        }

        private void InteractToBody(PawnBody pawnBody)
        {
            OnInteractToBody?.Invoke(pawnBody);
        }
    }
}