using Game.Gameplay.Pawn.Collliding;
using Game.Gameplay.Pawn.Movement;
using Game.Gameplay.Pawn.Size;
using Game.Gameplay.TagComponents;
using UnityEngine;
using Zenject;

namespace Game.Zenject
{
    public class PlayerComponentsInstaller : Installer<GameObject, PlayerComponentsInstaller>
    {
        private GameObject _playerGameObject;

        [Inject]
        private void Construct(GameObject playerGameObject)
        {
            _playerGameObject = playerGameObject;
        }

        public override void InstallBindings()
        {
            Container.
                Bind<Player>()
                .FromComponentOn(_playerGameObject)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PawnSprint>()
                .FromComponentOn(_playerGameObject)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PawnSize>()
                .FromComponentOn(_playerGameObject)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<PawnBody>()
                .FromComponentInHierarchy(_playerGameObject)
                .AsSingle()
                .Lazy();
        }
    }
}