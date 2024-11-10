using Game.Gameplay.StateServices;
using Game.Gameplay.TagComponents;
using Game.Zenject;
using Game.Zenject.Signals;
using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Spawners
{
    public class PlayerSpawner : MonoBehaviour, IInitializable, IRestartObject
    {
        private Player.Pool _pool;
        private SignalBus _signalBus;
        private DiContainer _container;
        private PlayerSpawnerParameters _parameters;

        [Inject]
        private void Construct(Player.Pool pool, SignalBus signalBus, DiContainer container, PlayerSpawnerParameters parameters)
        {
            _pool = pool;
            _signalBus = signalBus;
            _container = container;
            _parameters = parameters;
        }

        public void Initialize()
        {
            Player player = SpawnPlayer();
            PlayerComponentsInstaller.Install(_container, player.gameObject);

            _signalBus.Subscribe<GameEndSignal>(OnGameEnd);
        }

        private Player SpawnPlayer()
        {
            Player.SpawnParameters spawnParameters = new(Vector3.zero);
            Player player = _pool.Spawn(spawnParameters);
            return player;
        }

        public void Restart()
        {
            if (_pool.PlayersList.Count > 0)
                _pool.Despawn(_pool.PlayersList.First());

            SpawnPlayer();
        }

        private void OnGameEnd()
        {
            if (_pool.PlayersList.Count > 0)
                _pool.Despawn(_pool.PlayersList.First());
        }
    }

    [Serializable]
    public struct PlayerSpawnerParameters
    {

    }
}