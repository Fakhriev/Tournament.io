using Pools;
using Game.Gameplay.TagComponents;
using UnityEngine;
using Zenject;

namespace Game.Zenject.ScriptableObjectInstallers
{
    [CreateAssetMenu(fileName = "GamePoolsSettingsInstaller", menuName = "Installers/Game Pools Settings Installer")]
    public class GamePoolsSettingsInstaller : ScriptableObjectInstaller<GamePoolsSettingsInstaller>
    {
        [Header("Game Pools Parameters")]
        [SerializeField]
        private PoolParameters _playerPoolParameters;

        [SerializeField] 
        private PoolParameters _enemyPoolParameters;

        [SerializeField]
        private PoolParameters _bossPoolParameters;

        [SerializeField] 
        private PoolParameters _armorFragmentPoolParameters;

        [SerializeField] 
        private PoolParameters _applePoolParameters;

        [SerializeField] 
        private PoolParameters _goldCoinPoolParameters;

        [SerializeField]
        private PoolParameters _spikyShieldPoolParameters;

        [SerializeField]
        private PoolParameters _appleTrashProjectilePoolParameters;

        [SerializeField]
        private PoolParameters _lightningStrikeProjectilePoolParameters;

        [Header("UI Pool Parameters")]
        [SerializeField] 
        private PoolParameters _markerPoolParameters;

        public override void InstallBindings()
        {
            Container.BindInstance(_playerPoolParameters).WithId(nameof(Player));
            Container.BindInstance(_enemyPoolParameters).WithId(nameof(Enemy));
            Container.BindInstance(_bossPoolParameters).WithId(nameof(Boss));

            Container.BindInstance(_armorFragmentPoolParameters).WithId(nameof(ArmorFragment));
            Container.BindInstance(_applePoolParameters).WithId(nameof(Apple));
            Container.BindInstance(_goldCoinPoolParameters).WithId(nameof(GoldCoin));

            Container.BindInstance(_spikyShieldPoolParameters).WithId(nameof(SpikyShieldObject));
            Container.BindInstance(_appleTrashProjectilePoolParameters).WithId(nameof(AppleTrashProjectile));
            Container.BindInstance(_lightningStrikeProjectilePoolParameters).WithId(nameof(LightningStrikeProjectile));

            Container.BindInstance(_markerPoolParameters).WithId(nameof(Marker));
        }
    }
}