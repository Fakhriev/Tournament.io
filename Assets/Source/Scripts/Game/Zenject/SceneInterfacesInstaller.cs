using Game.Gameplay.StateServices;
using Zenject;

namespace Game.Zenject
{
    public class SceneInterfacesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().FromComponentsInHierarchy().AsSingle().NonLazy();
            Container.Bind<IPreRestartObject>().FromComponentsInHierarchy().AsCached().NonLazy();
            Container.Bind<IRestartObject>().FromComponentsInHierarchy().AsCached().NonLazy();
        }
    }
}