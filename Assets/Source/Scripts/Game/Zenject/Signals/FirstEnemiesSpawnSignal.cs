using Game.Gameplay.TagComponents;

namespace Game.Zenject.Signals
{
    public class FirstEnemiesSpawnSignal
    {
        public Enemy[] Enemies { get; private set; }

        public FirstEnemiesSpawnSignal(Enemy[] enemies)
        {
            Enemies = enemies;
        }
    }
}
