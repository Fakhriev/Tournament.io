using Game.Gameplay.Abstracts;
using UnityEngine;

namespace Game.Gameplay.TagComponents
{
    public partial class AppleTrashProjectile
    {
        public struct SpawnParameters
        {
            public IPawnCharacter Owner { get; private set; }

            public Vector3 SpawnPosition { get; private set; }

            public Quaternion SpawnRotation { get; private set; }

            public SpawnParameters(IPawnCharacter owner, Vector3 spawnPosition, Quaternion spawnRotation)
            {
                Owner = owner;
                SpawnPosition = spawnPosition;
                SpawnRotation = spawnRotation;
            }
        }
    }
}