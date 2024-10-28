using Game.Gameplay.Behavior;
using Game.Gameplay.Pawn.Movement;
using Game.Gameplay.Pawn.Size;
using Game.Gameplay.Spawners;
using Game.Gameplay.TagComponents;
using Game.Gameplay.Stage;
using Game.Gameplay.Utility;
using UnityEngine;
using Zenject;
using Game.Gameplay.Powers.BehaviorComponents;

namespace Game.Zenject.ScriptableObjectInstallers
{
    [CreateAssetMenu(fileName = "GameplaySettingsInstaller", menuName = "Installers/Gameplay Settings Installer")]
    public class GameplaySettingsInstaller : ScriptableObjectInstaller<GameplaySettingsInstaller>
    {
        [Header("Game Tag Components Parameters")]
        [SerializeField]
        private PlayerParameters _playerParameters;

        [SerializeField]
        private EnemyParameters _enemyParameters;

        [SerializeField]
        private BossParameters _bossParameters;

        [SerializeField] 
        private ArmorFragmentParameters _armorFragmentParameters;

        [SerializeField] 
        private AppleParameters _appleParameters;

        [SerializeField] 
        private GoldCoinParameters _goldCoinParameters;

        [Space]
        [SerializeField]
        private SpikyShieldObjectParameters _spikyShieldObjectParameters;

        [SerializeField]
        private LightningStrikeProjectileParameters _lightningStrikeProjectileParameters;

        [Header("UI Components Parameters")]
        [SerializeField]
        private MarkerParameters _markerParameters;

        [Header("Pawn Parameters")]
        [SerializeField]
        private PawnMovementParameters _pawnMovementParameters;

        [SerializeField]
        private PawnSprintParameters _pawnSprintParameters;

        [SerializeField] 
        private PawnSizeParameters _pawnSizeParameters;

        [Header("Powers Parameters")]
        [SerializeField]
        private SpikyShieldPowerParameters _spikyShieldPowerParameters;

        [SerializeField]
        private LightningStrikePowerParameters _lightningStrikePowerParameters;

        [SerializeField]
        private SprintIncreaseBySizePowerParameters _sprintIncreaseBySizePowerParameters;

        [Header("Spawners Parameters")]
        [SerializeField] 
        private PlayerSpawnerParameters _playerSpawnerParameters;

        [SerializeField]
        private EnemySpawnerParameters _enemySpawnerParameters;

        [SerializeField]
        private BossSpawnerParameters _bossSpawnerParameters;

        [SerializeField] 
        private ArmorFragmentsSpawnerParameters _armorFragmentsSpawnerParameters;

        [SerializeField] 
        private ApplesSpawnerParameters _applesSpawnerParameters;

        [SerializeField] 
        private GoldCoinsSpawnerParameters _goldCoinsSpawnerParameters;

        [SerializeField] 
        private MarkerSpawnerParameters _markerSpawnerParameters;

        [Header("Utilities Parameters")]
        [SerializeField]
        private PowersDistributorParameters _powersDistributorParameters;

        [SerializeField] 
        private CameraSizeCorrectorParameters _cameraSizeCorrectorParameters;

        [SerializeField] 
        private EnemyBehaviorParameters _enemyBehaviorParameters;

        [SerializeField] 
        private GameTimerParameters _gameTimerParameters;

        public override void InstallBindings()
        {
            Container.BindInstance(_playerParameters);
            Container.BindInstance(_enemyParameters);
            Container.BindInstance(_bossParameters);
            Container.BindInstance(_armorFragmentParameters);
            Container.BindInstance(_appleParameters);
            Container.BindInstance(_goldCoinParameters);

            Container.BindInstance(_spikyShieldObjectParameters);
            Container.BindInstance(_lightningStrikeProjectileParameters);

            Container.BindInstance(_markerParameters);

            Container.BindInstance(_pawnMovementParameters);
            Container.BindInstance(_pawnSprintParameters);
            Container.BindInstance(_pawnSizeParameters);

            Container.BindInstance(_spikyShieldPowerParameters);
            Container.BindInstance(_lightningStrikePowerParameters);
            Container.BindInstance(_sprintIncreaseBySizePowerParameters);

            Container.BindInstance(_playerSpawnerParameters);
            Container.BindInstance(_enemySpawnerParameters);
            Container.BindInstance(_bossSpawnerParameters);
            Container.BindInstance(_armorFragmentsSpawnerParameters);            
            Container.BindInstance(_applesSpawnerParameters);
            Container.BindInstance(_goldCoinsSpawnerParameters);
            Container.BindInstance(_markerSpawnerParameters);

            Container.BindInstance(_powersDistributorParameters);
            Container.BindInstance(_cameraSizeCorrectorParameters);
            Container.BindInstance(_enemyBehaviorParameters);
            Container.BindInstance(_gameTimerParameters);
        }
    }
}