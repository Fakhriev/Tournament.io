using Game.Gameplay.Behavior;
using Game.Gameplay.Pawn;
using Game.Gameplay.Pawn.Collliding;
using Game.Gameplay.Pawn.Movement;
using Game.Gameplay.Pawn.Movement.Sprint.SprintControll;
using Game.Gameplay.Pawn.Size;
using Game.Gameplay.Spawners;
using Game.Gameplay.Utility;
using Game.Zenject.Signals;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class Enemy : MonoBehaviour
    {
        private Pool _pool;
        private SignalBus _signalBus;
        private DiContainer _container;

        private PawnMovement _movement;
        private PawnActivator _activator;
        private PawnCollectables _collectables;
        private EnemyParameters _parameters;

        private GoldCoinsSpawner _goldCoinsSpawner;
        private ArmorFragmentsSpawner _armorFragmentsSpawner;

        private PawnBody _body;
        private EnemyBehavior _enemyBehavior;

        private int _index;

        [Inject]
        private void Construct(Pool pool, DiContainer container, SignalBus signalBus,
            PawnMovement movement, PawnActivator activator, PawnCollectables collectables, EnemyParameters parameters, 
            GoldCoinsSpawner goldCoinsSpawner, ArmorFragmentsSpawner armorFragmentsSpawner)
        {
            _pool = pool;
            _signalBus = signalBus;
            _container = container;

            _container.BindInstance(parameters.PawnPartsParameters);
            _container.Bind<ISprintController>().To<ManualSprintController>().FromNew().AsSingle();

            _movement = movement;
            _activator = activator;
            _parameters = parameters;
            _collectables = collectables;

            _goldCoinsSpawner = goldCoinsSpawner;
            _armorFragmentsSpawner = armorFragmentsSpawner;
        }

        private void Start()
        {
            _body = _container.Resolve<PawnBody>();
            _body.OnHitted += Deactivate;

            _enemyBehavior = _container.InstantiateComponent<EnemyBehavior>(gameObject);
            _container.Resolve<PawnParts>().SetLayers(Layers.Enemy);
        }

        public void Activate(SpawnParameters spawnParameters)
        {
            _activator.Activate();

            _index = spawnParameters.Index;
            gameObject.name = gameObject.name.Replace(Constants.IndexPlace, _index.ToString());

            transform.position = spawnParameters.SpawnPosition;

            if(spawnParameters.ArmorFragments > 0)
            {
                for (int i = 0; i < spawnParameters.ArmorFragments; i++)
                    _body.ArmorUp(null);
            }
        }

        private void Deactivate(PawnWeapon byWeapon)
        {
            if (byWeapon.gameObject.layer == Layers.Boss)
                return;

            gameObject.name = gameObject.name.Replace(_index.ToString(), Constants.IndexPlace);

            _pool.Despawn(this);
            _goldCoinsSpawner.SpawnCoins(transform.position, _collectables.Parameters);
            _armorFragmentsSpawner.SpawnArmorFragments(transform.position, _collectables.Parameters);

            _signalBus.Fire<EnemyDieSignal>(new(this));
        }
    }

    [Serializable]
    public struct EnemyParameters
    {
        public PawnPartsParameters PawnPartsParameters;
    }
}