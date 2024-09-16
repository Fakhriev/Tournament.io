using UnityEngine;

namespace Game.Gameplay.TagComponents
{
    public partial class Enemy
    {
        public struct SpawnParameters
        {
            public int Index { get; private set; }

            public Vector3 SpawnPosition { get; private set; }

            public int ArmorFragments { get; private set; }

            public SpawnParameters(int index, Vector3 spawnPosition, int armorFragments)
            {
                Index = index;
                SpawnPosition = spawnPosition;
                ArmorFragments = armorFragments;
            }
        }
    }
}