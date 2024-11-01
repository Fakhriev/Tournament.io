using Game.Gameplay.Abstracts;
using System;

namespace Game.Gameplay.TagComponents
{
    public partial class SpikyShieldObject
    {
        [Serializable]
        public struct SpawnParameters
        {
            public IPawnCharacter Owner { get; private set; }

            public SpawnParameters(IPawnCharacter owner)
            {
                Owner = owner;
            }
        }
    }
}