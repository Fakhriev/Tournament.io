using UnityEngine;

namespace Game.Gameplay.Abstracts
{
    public class ObjectPartCollider : MonoBehaviour
    {
        [field: SerializeField]
        public ObjectPartBase Base { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.activeInHierarchy == false)
                return;

            Base.TriggerEnter2D(collision);
        }
    }
}