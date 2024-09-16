using Game.Gameplay.Abstracts;
using Game.Gameplay.Pawn.Collliding;
using System;
using UnityEngine;

namespace Game.Gameplay.InteractableObject
{
    public class InteractableObjectBody : ObjectPartBase
    {
        public Action<PawnBody> OnCollide;

        public override void TriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<ObjectPartCollider>(out var partCollider) && partCollider.Base is PawnBody pawnBody)
            {
                OnCollide?.Invoke(pawnBody);
            }
        }
    }
}