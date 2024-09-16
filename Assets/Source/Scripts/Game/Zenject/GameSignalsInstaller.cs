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
            Container.DeclareSignal<EnemyDieSignal>();
            Container.DeclareSignal<BossDieSignal>();
            Container.DeclareSignal<TimerEndSignal>();
        }
    }
}