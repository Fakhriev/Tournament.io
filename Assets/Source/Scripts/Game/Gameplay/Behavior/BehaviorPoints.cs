using UnityEngine;

namespace Game.Gameplay.Behavior
{
    public class BehaviorPoints : MonoBehaviour
    {
        [field: SerializeField]
        public Transform[] Points { get; private set; }
    }
}