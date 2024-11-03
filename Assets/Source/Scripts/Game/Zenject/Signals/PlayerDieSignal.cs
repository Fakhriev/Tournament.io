using Game.Gameplay.Abstracts;
using Game.Gameplay.TagComponents;

namespace Game.Zenject.Signals
{
    public class PlayerDieSignal
    {
        public Player Player { get; private set; }
        public IHitSource HitSource { get; private set; }

        public PlayerDieSignal(Player player, IHitSource hitSource)
        {
            Player = player;
            HitSource = hitSource;
        }
    }
}