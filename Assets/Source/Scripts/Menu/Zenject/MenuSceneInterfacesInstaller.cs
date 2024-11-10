using Zenject;

namespace Menu.Zenject
{
    public class MenuSceneInterfacesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInitializable>().FromComponentsInHierarchy().AsSingle().NonLazy();
        }
    }
}