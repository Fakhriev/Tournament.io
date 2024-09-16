using System;
using UnityEngine;

namespace Game.Gameplay.TagComponents
{
    public partial class Apple
    {
        [Serializable]
        public struct SpawnParameters
        {
            public int Index { get; private set; }

            public Vector3 SpawnPosition { get; private set; }

            public bool SpawnAnimate { get; private set; }

            public SpawnParameters(int index, Vector3 spawnPosition, bool spawnAnimate)
            {
                Index = index;
                SpawnPosition = spawnPosition;
                SpawnAnimate = spawnAnimate;
            }
        }
    }
}