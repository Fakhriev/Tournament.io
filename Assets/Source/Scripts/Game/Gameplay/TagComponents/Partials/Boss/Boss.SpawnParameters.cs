using System;
using UnityEngine;

namespace Game.Gameplay.TagComponents
{
    public partial class Boss
    {
        [Serializable]
        public struct SpawnParameters
        {
            public Vector3 SpawnPosition { get; private set; }

            public SpawnParameters(Vector3 spawnPosition)
            {
                SpawnPosition = spawnPosition;
            }
        }
    }
}