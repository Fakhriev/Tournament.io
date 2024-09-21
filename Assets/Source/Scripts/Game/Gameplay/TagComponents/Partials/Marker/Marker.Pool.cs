using System.Collections.Generic;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class Marker
    {
        public class Pool : MonoMemoryPool<SpawnParameters, Marker>
        {
            public List<Marker> ActiveMarkers = new();

            protected override void OnCreated(Marker item)
            {
                base.OnCreated(item);
                item.Initialize();
            }

            protected override void OnSpawned(Marker item)
            {
                base.OnSpawned(item);
                ActiveMarkers.Add(item);
            }

            protected override void OnDespawned(Marker item)
            {
                base.OnDespawned(item);
                ActiveMarkers.Remove(item);
            }

            protected override void Reinitialize(SpawnParameters p1, Marker item)
            {
                base.Reinitialize(p1, item);
                item.Activate(p1);
            }
        }
    }
}
