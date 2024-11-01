using System.Collections.Generic;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class Marker
    {
        public class Pool : MonoMemoryPool<SpawnParameters, Marker>
        {
            public List<Marker> ActiveMarkers = new();

            protected override void OnCreated(Marker marker)
            {
                base.OnCreated(marker);
                marker.Initialize();
            }

            protected override void OnSpawned(Marker marker)
            {
                base.OnSpawned(marker);
                ActiveMarkers.Add(marker);
            }

            protected override void OnDespawned(Marker marker)
            {
                base.OnDespawned(marker);
                ActiveMarkers.Remove(marker);
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, Marker marker)
            {
                marker.Activate(spawnParameters);
            }
        }
    }
}
