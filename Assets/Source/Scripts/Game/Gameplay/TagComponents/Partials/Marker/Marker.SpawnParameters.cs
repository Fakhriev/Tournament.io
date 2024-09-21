using System;
using UnityEngine;

namespace Game.Gameplay.TagComponents
{
    public partial class Marker
    {
        [Serializable]
        public struct SpawnParameters
        {
            public Color Color;
            public GameObject Target;

            public SpawnParameters(Color color, GameObject target)
            {
                Color = color;
                Target = target;
            }
        }
    }
}
