using Game.Gameplay.Abstracts;
using Game.Gameplay.Pawn.Collliding;
using System;
using UnityEngine;

namespace Game.Gameplay.InteractableObject
{
    public class InteractableObjectBody : ObjectPartBase
    {
        public Action<PawnBody> OnBodyCollide;
        public Action<PawnWeapon> OnWeaponCollide;

        public override void TriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<ObjectPartCollider>(out var partCollider))
            {
                if(partCollider.Base is PawnBody pawnBody)
                    OnBodyCollide?.Invoke(pawnBody);

                if (partCollider.Base is PawnWeapon pawnWeapon)
                    OnWeaponCollide?.Invoke(pawnWeapon);
            }
        }
    }
}