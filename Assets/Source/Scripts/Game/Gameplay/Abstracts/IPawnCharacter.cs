using UnityEngine;
using Zenject;

namespace Game.Gameplay.Abstracts
{
    public interface IPawnCharacter
    {
        public GameObject PawnGameObject { get; }
        public DiContainer PawnContainer { get; }
    }
}