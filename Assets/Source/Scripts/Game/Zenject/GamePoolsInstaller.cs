using Game.Gameplay.Utility;
using Game.Gameplay.TagComponents;
using UnityEngine;
using Zenject;
using Game.Gameplay.Pools;

namespace Game.Zenject
{
    public class GamePoolsInstaller : MonoInstaller
    {
        [Header("Parents")]
        [SerializeField] 
        private Transform _playerParent;

        [SerializeField]
        private Transform _enemyParent;

        [SerializeField]
        private Transform _bossParent;

        [SerializeField] 
        private Transform _armorFragmentsParent;

        [SerializeField] 
        private Transform _applesParent;

        [SerializeField] 
        private Transform _goldCoinsParent;

        [Space]
        [SerializeField] 
        private Transform _markersParent;

        [Space]
        [SerializeField]
        private Transform _lightningStrikeProjectilesParent;

        [Header("Prefabs")]
        [SerializeField]
        private GameObject _pawnPrefab;

        [SerializeField] 
        private GameObject _interactableObjectPrefab;

        [SerializeField] 
        private GameObject _markerPrefab;

        private PoolParameters _playerPoolParameters;
        private PoolParameters _enemyPoolParameters;
        private PoolParameters _bossPoolParameters;

        private PoolParameters _armorFragmentPoolParameters;
        private PoolParameters _applePoolParameters;
        private PoolParameters _goldCoinPoolParameters;

        private PoolParameters _markerPoolParameters;

        private PoolParameters _lightningStrikeProjectilePoolParameters;

        [Inject]
        private void Construct([Inject(Id = nameof(Player))] PoolParameters playerPoolParameters,
            [Inject(Id = nameof(Enemy))] PoolParameters enemyPoolParameters,
            [Inject(Id = nameof(Boss))] PoolParameters bossPoolParameters,
            [Inject(Id = nameof(ArmorFragment))] PoolParameters armorFragmentPoolParameters,
            [Inject(Id = nameof(Apple))] PoolParameters applePoolParameters,
            [Inject(Id = nameof(GoldCoin))] PoolParameters goldCoinPoolParameters,
            [Inject(Id = nameof(Marker))] PoolParameters markerPoolParameters,
            [Inject(Id = nameof(LightningStrikeProjectile))] PoolParameters lightningStrikeProjectilePoolParameters)
        {
            _playerPoolParameters = playerPoolParameters;
            _enemyPoolParameters = enemyPoolParameters;
            _bossPoolParameters = bossPoolParameters;

            _armorFragmentPoolParameters = armorFragmentPoolParameters;
            _applePoolParameters = applePoolParameters;
            _goldCoinPoolParameters = goldCoinPoolParameters;

            _markerPoolParameters = markerPoolParameters;

            _lightningStrikeProjectilePoolParameters = lightningStrikeProjectilePoolParameters;
        }

        public override void InstallBindings()
        {
            Container
                .BindMemoryPool<Player, Player.Pool>()
                .WithFixedSize(_playerPoolParameters.FixedSize)
                .FromNewComponentOnNewPrefab(_pawnPrefab)
                .WithGameObjectName(_pawnPrefab.name + $" [{nameof(Player)}]")
                .UnderTransform(_playerParent);

            Container
                .BindMemoryPool<Enemy, Enemy.Pool>()
                .WithInitialSize(_enemyPoolParameters.InitialSize)
                .WithMaxSize(_enemyPoolParameters.MaxSize)
                .FromNewComponentOnNewPrefab(_pawnPrefab)
                .WithGameObjectName(_pawnPrefab.name + $" [{nameof(Enemy)}] [{Constants.IndexPlace}]")
                .UnderTransform(_enemyParent);

            Container
                .BindMemoryPool<Boss, Boss.Pool>()
                .WithFixedSize(_bossPoolParameters.FixedSize)
                .FromNewComponentOnNewPrefab(_pawnPrefab)
                .WithGameObjectName(_pawnPrefab.name + $" [{nameof(Boss)}]")
                .UnderTransform(_bossParent);

            Container
                .BindMemoryPool<ArmorFragment, ArmorFragment.Pool>()
                .WithInitialSize(_armorFragmentPoolParameters.InitialSize)
                .WithMaxSize(_armorFragmentPoolParameters.MaxSize)
                .FromNewComponentOnNewPrefab(_interactableObjectPrefab)
                .WithGameObjectName(_interactableObjectPrefab.name + $" [{nameof(ArmorFragment)}] [{Constants.IndexPlace}]")
                .UnderTransform(_armorFragmentsParent);

            Container
                .BindMemoryPool<Apple, Apple.Pool>()
                .WithInitialSize(_applePoolParameters.InitialSize)
                .WithMaxSize(_applePoolParameters.MaxSize)
                .FromNewComponentOnNewPrefab(_interactableObjectPrefab)
                .WithGameObjectName(_interactableObjectPrefab.name + $" [{nameof(Apple)}] [{Constants.IndexPlace}]")
                .UnderTransform(_applesParent);

            Container
                .BindMemoryPool<GoldCoin, GoldCoin.Pool>()
                .WithInitialSize(_goldCoinPoolParameters.InitialSize)
                .WithMaxSize(_goldCoinPoolParameters.MaxSize)
                .FromNewComponentOnNewPrefab(_interactableObjectPrefab)
                .WithGameObjectName(_interactableObjectPrefab.name + $" [{nameof(GoldCoin)}] [{Constants.IndexPlace}]")
                .UnderTransform(_goldCoinsParent);

            Container
                .BindMemoryPool<Marker, Marker.Pool>()
                .WithInitialSize(_markerPoolParameters.InitialSize)
                .WithMaxSize(_markerPoolParameters.MaxSize)
                .FromComponentInNewPrefab(_markerPrefab)
                .WithGameObjectName(_markerPrefab.name + $" [{Constants.IndexPlace}]")
                .UnderTransform(_markersParent);

            Container.
                BindMemoryPool<LightningStrikeProjectile, LightningStrikeProjectile.Pool>()
                .WithInitialSize(_lightningStrikeProjectilePoolParameters.InitialSize)
                .WithMaxSize(_lightningStrikeProjectilePoolParameters.MaxSize)
                .FromNewComponentOnNewPrefab(_interactableObjectPrefab)
                .WithGameObjectName($"{nameof(LightningStrikeProjectile)}")
                .UnderTransform(_lightningStrikeProjectilesParent);
        }
    }
}