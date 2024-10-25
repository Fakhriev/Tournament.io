using UnityEngine;

namespace Game.Gameplay.Utility.Extensions
{
    public static class ComponentExtensions
    {
        public static bool HasComponent<T>(this GameObject gameObject)
        {
            return gameObject.TryGetComponent(out T component);
        }
    }
}