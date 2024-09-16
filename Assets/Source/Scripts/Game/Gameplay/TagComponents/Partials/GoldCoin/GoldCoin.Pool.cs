using System.Collections.Generic;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class GoldCoin
    {
        public class Pool : MonoMemoryPool<SpawnParameters, GoldCoin>
        {
            public List<GoldCoin> ActiveGoldCoins = new();

            protected override void OnCreated(GoldCoin goldCoin)
            {
                base.OnCreated(goldCoin);
                goldCoin.Initialize();
            }

            protected override void OnSpawned(GoldCoin goldCoint)
            {
                base.OnSpawned(goldCoint);
                ActiveGoldCoins.Add(goldCoint);
            }

            protected override void OnDespawned(GoldCoin goldCoin)
            {
                base.OnDespawned(goldCoin);
                ActiveGoldCoins.Remove(goldCoin);
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, GoldCoin goldCoin)
            {
                goldCoin.Activate(spawnParameters);
            }
        }
    }
}