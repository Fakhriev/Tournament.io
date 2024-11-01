using Game.Gameplay.TagComponents;
using Game.Gameplay.Stage;
using System;
using UnityEngine;
using Zenject;
using Assets.Source.Scripts.Game.Gameplay.Stage;
using Game.Gameplay.Utility.Extensions;
using Redcode.Extensions;
using Game.Zenject.Signals;

namespace Game.Gameplay.Spawners
{
    public class BossSpawner : MonoBehaviour, IRestartObject
    {
        [SerializeField] private Transform[] _spawnPoints;

        private Boss.Pool _pool;
        private SignalBus _signalBus;
        private GameTimer _gameTimer;
        private BossSpawnerParameters _parameters;

        public Boss Boss { get; private set; }
        public bool BossSpawned => Boss != null;

        [Inject]
        private void Construct(Boss.Pool pool, SignalBus signalBus, GameTimer gameTimer, BossSpawnerParameters parameters)
        {
            _pool = pool;
            _signalBus = signalBus;
            _gameTimer = gameTimer;
            _parameters = parameters;
        }

        private void Update()
        {
            if (BossSpawned)
                return;

            if(_gameTimer.RoundTimePassed >= _parameters.SpawnTime)
            {
                SpawnBoss();
            }
        }

        [ContextMenu("SpawnBoss")]
        private void SpawnBoss()
        {
            Transform spawnPoint = FindSpawnPoint();
            Boss.SpawnParameters spawnParameters = new(spawnPoint.position);
            Boss = _pool.Spawn(spawnParameters);

            _signalBus.Fire(new BossSpawnSignal(Boss));
        }

        private Transform FindSpawnPoint()
        {
            Transform spawnPoint = _spawnPoints.GetRandomElementBeyondCamera(Vector3.one);

            if (spawnPoint == null)
                spawnPoint = _spawnPoints.GetRandomElement();

            return spawnPoint;
        }

        public void Restart()
        {
            if (BossSpawned && Boss.gameObject.activeSelf)
                _pool.Despawn(Boss);

            Boss = null;
        }
    }

    [Serializable]
    public struct BossSpawnerParameters
    {
        public float SpawnTime;
    }
}