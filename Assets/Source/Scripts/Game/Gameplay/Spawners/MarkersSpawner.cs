using Game.Gameplay.StateServices;
using Game.Gameplay.TagComponents;
using Game.Zenject.Signals;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Spawners
{
    public class MarkersSpawner : MonoBehaviour, IPreRestartObject
    {
        private Marker.Pool _pool;
        private SignalBus _signalBus;
        private MarkerSpawnerParameters _parameters;

        [Inject]
        private void Construct(Marker.Pool pool, SignalBus signalBus, MarkerSpawnerParameters parameters)
        {
            _pool = pool;
            _signalBus = signalBus;
            _parameters = parameters;
        }

        private void Awake()
        {
            _signalBus.Subscribe<FirstEnemiesSpawnSignal>(SpawnEnemyMarkers);
            _signalBus.Subscribe<BossSpawnSignal>(SpawnBossMarker);
        }

        private void SpawnEnemyMarkers(FirstEnemiesSpawnSignal firstEnemiesSpawnSignal)
        {
            foreach (var enemy in firstEnemiesSpawnSignal.Enemies)
            {
                Marker.SpawnParameters spawnParameters = new(_parameters.EnemyMarkerColor, enemy.gameObject);
                Marker marker = _pool.Spawn(spawnParameters);
            }
        }

        private void SpawnBossMarker(BossSpawnSignal bossSpawnSignal)
        {
            Marker.SpawnParameters spawnParameters = new(_parameters.BossMarkerColor, bossSpawnSignal.Boss.gameObject);
            Marker marker = _pool.Spawn(spawnParameters);
        }

        public void PreRestart()
        {
            List<Marker> activeMarkers = new(_pool.ActiveMarkers);

            foreach (var marker in activeMarkers)
                _pool.Despawn(marker);
        }
    }

    [Serializable]
    public struct MarkerSpawnerParameters
    {
        public Color EnemyMarkerColor;
        public Color BossMarkerColor;
    }
}