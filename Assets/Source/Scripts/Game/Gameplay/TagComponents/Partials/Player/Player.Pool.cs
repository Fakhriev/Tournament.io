using System.Collections.Generic;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class Player
    {
        public class Pool : MonoMemoryPool<SpawnParameters, Player>
        {
            public List<Player> PlayersList = new();

            protected override void OnCreated(Player player)
            {
                base.OnCreated(player);
                player.Initialize();
            }

            protected override void OnSpawned(Player player)
            {
                base.OnSpawned(player);
                PlayersList.Add(player);
            }

            protected override void OnDespawned(Player player)
            {
                base.OnDespawned(player);
                PlayersList.Remove(player);
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, Player player)
            {
                player.Activate(spawnParameters);
            }
        }
    }
}