using Game.Gameplay.Pawn;
using Game.Gameplay.StateServices;
using Game.Gameplay.TagComponents;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Spawners
{
    public class ArmorFragmentsSpawner : MonoBehaviour, IRestartObject
    {
        private ArmorFragment.Pool _pool;
        private ArmorFragmentsSpawnerParameters _parameters;

        [Inject]
        private void Construct(ArmorFragment.Pool pool, ArmorFragmentsSpawnerParameters parameters)
        {
            _pool = pool;
            _parameters = parameters;
        }

        public void SpawnArmorFragments(Vector3 position, PawnCollectablesParameters pawnCollectablesParameters)
        {
            int spawnAmount = _parameters.MinimalAmount + pawnCollectablesParameters.ArmorFragments / _parameters.IncrementValue;

            for(int i = 0; i < spawnAmount; i++)
            {
                ArmorFragment.SpawnParameters spawnParameters = new (i, position);
                ArmorFragment armorFragment = _pool.Spawn(spawnParameters);
            }
        }

        public void Restart()
        {
            List<ArmorFragment> activeArmorFragments = new(_pool.ActiveArmorFragments);

            foreach (var armorFragment in activeArmorFragments)
                _pool.Despawn(armorFragment);
        }
    }

    [Serializable]
    public struct ArmorFragmentsSpawnerParameters
    {
        public int MinimalAmount;
        public int IncrementValue;
    }
}