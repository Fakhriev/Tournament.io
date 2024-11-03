using Game.UI;

namespace Game.Zenject.Signals
{
    public class LateGameEndSignal
    {
        public GameEndType GameEndType { get; private set; }

        public LateGameEndSignal(GameEndType gameEndType)
        {
            GameEndType = gameEndType;
        }
    }
}