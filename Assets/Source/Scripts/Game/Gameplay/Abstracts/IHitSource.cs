using UnityEngine;

namespace Game.Gameplay.Abstracts
{
    public interface IHitSource
    {
        public IPawnCharacter Owner { get; }
    }
}