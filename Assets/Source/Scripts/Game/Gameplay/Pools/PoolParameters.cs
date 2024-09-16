using System;
using UnityEngine;

namespace Game.Gameplay.Pools
{
    [Serializable]
    public struct PoolParameters
    {
        public int InitialSize;
        public int MaxSize;

        [Space]
        public int FixedSize;
    }
}