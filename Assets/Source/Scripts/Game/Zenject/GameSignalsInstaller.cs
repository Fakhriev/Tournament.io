using Game.Zenject.Signals;
using Zenject;

namespace Game.Zenject
{
    public class GameSignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<PlayerDieSignal>();

            Container.DeclareSignal<FirstEnemiesSpawnSignal>();
            Container.DeclareSignal<EnemySpawnSignal>();
            Container.DeclareSignal<EnemyDieSignal>();

            Container.DeclareSignal<BossSpawnSignal>();
            Container.DeclareSignal<BossDieSignal>();
            
            Container.DeclareSignal<TimerEndSignal>();
            Container.DeclareSignal<GameEndSignal>();
            Container.DeclareSignal<LateGameEndSignal>();
        }
    }
}