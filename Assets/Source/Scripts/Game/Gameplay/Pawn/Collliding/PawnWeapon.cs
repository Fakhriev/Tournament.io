using Game.Gameplay.Abstracts;
using System;
using UnityEngine;

namespace Game.Gameplay.Pawn.Collliding
{
    public class PawnWeapon : ObjectPartBase
    {
        public Action<PawnBody> OnHit;

        public override void TriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<ObjectPartCollider>(out var partCollider) && partCollider.Base is PawnBody pawnBody)
            {
                pawnBody.Hit(this);
                OnHit?.Invoke(pawnBody);
            }
        }
    }
}