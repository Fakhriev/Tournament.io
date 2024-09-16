using Redcode.Extensions;
using UnityEngine;

namespace Game.Gameplay.Abstracts
{
    public abstract class ObjectPartBase : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer[] _spriteRenderers;

        [SerializeField]
        private Collider2D[] _colliders;

        public void SetSortingOrder(int value)
        {
            _spriteRenderers.ForEach(s => s.sortingOrder = value);
        }

        public void IgnoreCollisions(ObjectPartBase otherObject)
        {
            foreach(var c in _colliders)
            {
                foreach(var otherC in otherObject._colliders)
                {
                    Physics2D.IgnoreCollision(c, otherC);
                }
            }
        }

        public virtual void TriggerEnter2D(Collider2D collision)
        {
            
        }
    }
}