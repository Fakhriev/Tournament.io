using System;
using UnityEngine;

namespace Pools
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