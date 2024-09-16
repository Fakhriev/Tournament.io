using Game.Gameplay.Pawn.Collliding;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.InteractableObject
{
    public class InteractableObjectInteractions : MonoBehaviour
    {
        public Action<PawnBody> OnInteract;

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
            _body.OnCollide += Interact;
        }

        private void Interact(PawnBody pawnBody)
        {
            OnInteract?.Invoke(pawnBody);
        }
    }
}