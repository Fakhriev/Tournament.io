﻿using Game.UI;

namespace Game.Zenject.Signals
{
    public class GameEndSignal
    {
        public GameEndType GameEndType { get; private set; }

        public GameEndSignal(GameEndType gameEndType)
        {
            GameEndType = gameEndType;
        }
    }
}