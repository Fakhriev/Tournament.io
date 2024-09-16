using Game.Gameplay.TagComponents;
using UnityEngine;

namespace Game.Zenject.Signals
{
    public class PlayerDieSignal
    {
        public Player Player { get; private set; }

        public PlayerDieSignal(Player player)
        {
            Player = player;
        }
    }
}