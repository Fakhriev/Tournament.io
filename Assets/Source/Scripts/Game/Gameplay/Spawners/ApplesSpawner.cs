using Game.Gameplay.StateServices;
using Game.Gameplay.TagComponents;
using Game.Gameplay.Utility.Extensions;
using Redcode.Extensions;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Gameplay.Spawners
{
    public class ApplesSpawner : MonoBehaviour, IRestartObject
    {
        [SerializeField] 
        private Transform[] _spawnPoints;

        private Apple.Pool _pool;
        private ApplesSpawnerParameters _parameters;

        [Inject]
        private void Construct(Apple.Pool pool, ApplesSpawnerParameters parameters)
        {
            _pool = pool;
            _parameters = parameters;
        }

        private void Start()
        {
            SpawnFirstApples();
        }

        private void SpawnFirstApples()
        {
            for(int i = 0; i < _parameters.AlwaysActiveAmount; i++)
            {
                Vector3 randomRadius = (Random.insideUnitCircle * _parameters.SpawnRadius).InsertZ();
                Vector3 spawnPosition = _spawnPoints.GetRandomElement().position;
                SpawnApple(spawnPosition + randomRadius, false);
            }
        }

        private void Update()
        {
            if(_pool.NumActive < _parameters.AlwaysActiveAmount)
            {
                SpawnMissingApples();
            }
        }

        private void SpawnMissingApples()
        {
            while(_pool.NumActive < _parameters.AlwaysActiveAmount)
            {
                Vector3 spawnPosition = TryGetBeyondCameraSpawnPosition();
                SpawnApple(spawnPosition, false);
            }
        }

        private void SpawnApple(Vector3 position, bool spawnAnimate)
        {
            Apple.SpawnParameters spawnParameters = new(_pool.NumActive, position, spawnAnimate);
            Apple apple = _pool.Spawn(spawnParameters);
        }

        #region TryGetBeyondCameraSpawnPosition

        private Vector3 TryGetBeyondCameraSpawnPosition()
        {
            Transform pointBeyondCamera = _spawnPoints.GetRandomElementBeyondCamera(_parameters.SpawnRadius * 0.5f * Vector3.one);
            Vector3 randomSpawnRadius = (Random.insideUnitCircle * _parameters.SpawnRadius).InsertZ();

            if (pointBeyondCamera)
                return pointBeyondCamera.position + randomSpawnRadius;
            else
                return _spawnPoints.GetRandomElement().position + randomSpawnRadius;
        }

        #endregion

        public void Restart()
        {
            List<Apple> activeApples = new(_pool.ActiveApples);

            foreach (var apple in activeApples)
                _pool.Despawn(apple);

            SpawnFirstApples();
        }
    }

    [Serializable]
    public struct ApplesSpawnerParameters
    {
        public int AlwaysActiveAmount;
        public float SpawnRadius;
    }
}