using Game.Gameplay.TagComponents;
using Game.Gameplay.Stage;
using Game.Gameplay.Utility.Extensions;
using Redcode.Extensions;
using System;
using System.Linq;
using UnityEngine;
using Zenject;
using Assets.Source.Scripts.Game.Gameplay.Stage;
using System.Collections.Generic;
using Game.Zenject.Signals;

namespace Game.Gameplay.Spawners
{
    public class EnemySpawner : MonoBehaviour, IRestartObject
    {
        [SerializeField] 
        private Transform[] _spawnPoints;

        private Enemy.Pool _pool;
        private SignalBus _signalBus;
        private GameTimer _gameTimer;
        private EnemySpawnerParameters _parameters;

        private int _middleGameEnemiesSpawnedAmount;

        [Inject]
        private void Construct(Enemy.Pool pool, SignalBus signalBus, GameTimer gameTimer, EnemySpawnerParameters parameters)
        {
            _pool = pool;
            _signalBus = signalBus;
            _gameTimer = gameTimer;
            _parameters = parameters;
        }

        private void Start()
        {
            SpawnFirstEnemies();
        }

        private void SpawnFirstEnemies()
        {
            var spawnPointsList = _spawnPoints.ToList();

            for (int i = 0; i < _parameters.StartEnemiesAmount; i++)
            {
                Transform spawnPointTransform = spawnPointsList.GetRandomElement();
                spawnPointsList.Remove(spawnPointTransform);

                SpawnEnemy(i, spawnPointTransform.position);
            }

            _signalBus.Fire(new FirstEnemiesSpawnSignal(_pool.ActiveEnemies.ToArray()));
        }

        private void Update()
        {
            if (_gameTimer.RoundTimeLeft < _parameters.SpawningDisableTimeLeft || _middleGameEnemiesSpawnedAmount > _parameters.MaximalMiddleGameEnemiesSpawnedAmount)
                return;

            if(_pool.NumActive < _parameters.MinimalEnemiesAmount)
            {
                SpawnGameStageEnemy();
            }
        }

        private void SpawnGameStageEnemy()
        {
            Transform pointBeyondCamera = _spawnPoints.GetRandomElementBeyondCamera(Vector3.one);
            Vector3 spawnPosition = pointBeyondCamera ? pointBeyondCamera.position : _spawnPoints.GetRandomElement().position;

            int armorFragments = Mathf.RoundToInt(_gameTimer.RoundTimePassed / _parameters.IncrementArmorFragmentsForSeconds);
            Enemy enemy = SpawnEnemy(_pool.NumInactive + 1, spawnPosition, armorFragments);
            _middleGameEnemiesSpawnedAmount++;
        }

        private Enemy SpawnEnemy(int index, Vector3 position, int armorFragments = 0)
        {
            Vector3 spawnPosition = position;

            Enemy.SpawnParameters spawnParameters = new(index, spawnPosition, armorFragments);
            Enemy enemy = _pool.Spawn(spawnParameters);

            _signalBus.Fire(new EnemySpawnSignal(enemy));
            return enemy;
        }

        public void Restart()
        {
            List<Enemy> activeEnemies = new(_pool.ActiveEnemies);

            foreach (var enemy in activeEnemies)
                _pool.Despawn(enemy);

            _middleGameEnemiesSpawnedAmount = 0;
            SpawnFirstEnemies();
        }
    }

    [Serializable]
    public struct EnemySpawnerParameters 
    {
        public int StartEnemiesAmount;
        public int MinimalEnemiesAmount;
        public int MaximalMiddleGameEnemiesSpawnedAmount;

        [Space]
        public float IncrementArmorFragmentsForSeconds;
        public float SpawningDisableTimeLeft;
    }
}