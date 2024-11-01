using Game.Gameplay.Abstracts;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn.Collliding
{
    public class PawnWeapon : ObjectPartBase, IHitSource
    {
        private IPawnCharacter _pawnCharacter;

        public IPawnCharacter Owner => _pawnCharacter;

        [Inject]
        private void Construct(IPawnCharacter pawnCharacter)
        {
            _pawnCharacter = pawnCharacter;
        }

        public override void TriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<ObjectPartCollider>(out var partCollider) && partCollider.Base is PawnBody pawnBody)
            {
                pawnBody.Hit(this);
            }
        }
    }
}