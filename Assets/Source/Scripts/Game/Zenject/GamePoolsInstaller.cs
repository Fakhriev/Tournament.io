using Game.Gameplay.Utility;
using Game.Gameplay.TagComponents;
using UnityEngine;
using Zenject;
using Game.Gameplay.Pools;

namespace Game.Zenject
{
    public class GamePoolsInstaller : MonoInstaller
    {
        [Header("Game Objects Parents")]
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

        [SerializeField]
        private Transform _spikyShieldObjectsParent;

        [SerializeField]
        private Transform _appleTrashProjectilesParent;

        [SerializeField]
        private Transform _lightningStrikeProjectilesParent;

        [Header("UI Objects Parents")]
        [SerializeField]
        private Transform _markersParent;

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

        private PoolParameters _spikyShieldObjectPoolParameters;
        private PoolParameters _appleTrashProjectilePoolParameters;
        private PoolParameters _lightningStrikeProjectilePoolParameters;

        private PoolParameters _markerPoolParameters;

        [Inject]
        private void Construct([Inject(Id = nameof(Player))] PoolParameters playerPoolParameters,
            [Inject(Id = nameof(Enemy))] PoolParameters enemyPoolParameters,
            [Inject(Id = nameof(Boss))] PoolParameters bossPoolParameters,
            [Inject(Id = nameof(ArmorFragment))] PoolParameters armorFragmentPoolParameters,
            [Inject(Id = nameof(Apple))] PoolParameters applePoolParameters,
            [Inject(Id = nameof(GoldCoin))] PoolParameters goldCoinPoolParameters,
            [Inject(Id = nameof(SpikyShieldObject))] PoolParameters spikyShieldObjectPoolParameters,
            [Inject(Id = nameof(SpikyShieldObject))] PoolParameters appleTrashProjectilePoolParameters,
            [Inject(Id = nameof(LightningStrikeProjectile))] PoolParameters lightningStrikeProjectilePoolParameters,
            [Inject(Id = nameof(Marker))] PoolParameters markerPoolParameters)
        {
            _playerPoolParameters = playerPoolParameters;
            _enemyPoolParameters = enemyPoolParameters;
            _bossPoolParameters = bossPoolParameters;

            _armorFragmentPoolParameters = armorFragmentPoolParameters;
            _applePoolParameters = applePoolParameters;
            _goldCoinPoolParameters = goldCoinPoolParameters;

            _spikyShieldObjectPoolParameters = spikyShieldObjectPoolParameters;
            _appleTrashProjectilePoolParameters = appleTrashProjectilePoolParameters;
            _lightningStrikeProjectilePoolParameters = lightningStrikeProjectilePoolParameters;

            _markerPoolParameters = markerPoolParameters;
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
                .BindMemoryPool<SpikyShieldObject, SpikyShieldObject.Pool>()
                .WithInitialSize(_spikyShieldObjectPoolParameters.InitialSize)
                .WithMaxSize(_spikyShieldObjectPoolParameters.MaxSize)
                .FromNewComponentOnNewPrefab(_interactableObjectPrefab)
                .WithGameObjectName(nameof(SpikyShieldObject))
                .UnderTransform(_spikyShieldObjectsParent);

            Container
                .BindMemoryPool<AppleTrashProjectile, AppleTrashProjectile.Pool>()
                .WithInitialSize(_appleTrashProjectilePoolParameters.InitialSize)
                .WithMaxSize(_appleTrashProjectilePoolParameters.MaxSize)
                .FromNewComponentOnNewPrefab(_interactableObjectPrefab)
                .WithGameObjectName(nameof(AppleTrashProjectile))
                .UnderTransform(_appleTrashProjectilesParent);

            Container
                .BindMemoryPool<LightningStrikeProjectile, LightningStrikeProjectile.Pool>()
                .WithInitialSize(_lightningStrikeProjectilePoolParameters.InitialSize)
                .WithMaxSize(_lightningStrikeProjectilePoolParameters.MaxSize)
                .FromNewComponentOnNewPrefab(_interactableObjectPrefab)
                .WithGameObjectName(nameof(LightningStrikeProjectile))
                .UnderTransform(_lightningStrikeProjectilesParent);

            Container
                .BindMemoryPool<Marker, Marker.Pool>()
                .WithInitialSize(_markerPoolParameters.InitialSize)
                .WithMaxSize(_markerPoolParameters.MaxSize)
                .FromComponentInNewPrefab(_markerPrefab)
                .WithGameObjectName(_markerPrefab.name + $" [{Constants.IndexPlace}]")
                .UnderTransform(_markersParent);
        }
    }
}