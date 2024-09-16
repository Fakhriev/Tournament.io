using System;
using UnityEngine;

namespace Game.Gameplay.TagComponents
{
    public partial class Player
    {

        [Serializable]
        public struct SpawnParameters
        {
            public Vector3 SpawnPosition;

            public SpawnParameters(Vector3 spawnPosition)
            {
                SpawnPosition = spawnPosition;
            }
        }
    }
}