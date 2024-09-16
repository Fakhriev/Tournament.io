using Assets.Source.Scripts.Game.Gameplay.Stage;
using Game.Gameplay.Pawn;
using Game.Gameplay.TagComponents;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Spawners
{
    public class GoldCoinsSpawner : MonoBehaviour, IRestartObject
    {
        private GoldCoin.Pool _pool;
        private GoldCoinsSpawnerParameters _parameters;

        [Inject]
        private void Construct(GoldCoin.Pool pool, GoldCoinsSpawnerParameters parameters)
        {
            _pool = pool;
            _parameters = parameters;
        }

        public void SpawnCoins(Vector3 position, PawnCollectablesParameters pawnCollectablesParameters)
        {
            int spawnAmount = pawnCollectablesParameters.GoldCoins;

            for (int i = 0; i < spawnAmount; i++)
            {
                GoldCoin.SpawnParameters spawnParameters = new(i, position);
                GoldCoin goldCoin = _pool.Spawn(spawnParameters);
            }
        }

        public void Restart()
        {
            List<GoldCoin> activeGoldCoins = new(_pool.ActiveGoldCoins);

            foreach (var goldCoin in activeGoldCoins)
                _pool.Despawn(goldCoin);
        }
    }

    [Serializable]
    public struct GoldCoinsSpawnerParameters
    {
    }
}