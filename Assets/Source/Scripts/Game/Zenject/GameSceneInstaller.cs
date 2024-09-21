using Assets.Source.Scripts.Game.Gameplay.Stage;
using Zenject;

namespace Game.Zenject
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().FromComponentsInHierarchy().AsSingle().NonLazy();
            Container.Bind<IPreRestartObject>().FromComponentsInHierarchy().AsCached().NonLazy();
            Container.Bind<IRestartObject>().FromComponentsInHierarchy().AsCached().NonLazy();
        }
    }
}