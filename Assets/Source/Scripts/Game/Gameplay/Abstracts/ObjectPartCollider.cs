using UnityEngine;

namespace Game.Gameplay.Abstracts
{
    public class ObjectPartCollider : MonoBehaviour
    {
        [field: SerializeField]
        public ObjectPartBase Base { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Base.TriggerEnter2D(collision);
        }
    }
}