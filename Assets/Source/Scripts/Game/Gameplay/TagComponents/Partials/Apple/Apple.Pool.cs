using System.Collections.Generic;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class Apple
    {
        public class Pool : MonoMemoryPool<SpawnParameters, Apple>
        {
            public List<Apple> ActiveApples = new();

            protected override void OnCreated(Apple apple)
            {
                base.OnCreated(apple);
                apple.Initialize();
            }

            protected override void OnSpawned(Apple apple)
            {
                base.OnSpawned(apple);
                ActiveApples.Add(apple);
            }

            protected override void OnDespawned(Apple apple)
            {
                base.OnDespawned(apple);
                ActiveApples.Remove(apple);
            }

            protected override void Reinitialize(SpawnParameters spawnParameters, Apple apple)
            {
                apple.Activate(spawnParameters);
            }
        }
    }
}