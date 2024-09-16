using UnityEngine;

namespace Game.Gameplay.TagComponents
{
    public partial class ArmorFragment
    {
        public struct SpawnParameters
        {
            public int Index { get; private set; }

            public Vector3 SpawnPosition { get; private set; }

            public SpawnParameters(int index, Vector3 spawnPosition)
            {
                Index = index;
                SpawnPosition = spawnPosition;
            }
        }
    }
}