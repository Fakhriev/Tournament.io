using Game.Gameplay.Pawn;
using Game.Gameplay.Pawn.Collliding;
using Game.Gameplay.Pawn.Movement;
using Game.Gameplay.Pawn.Movement.Sprint.SprintControll;
using Game.Gameplay.Spawners;
using Game.Zenject.Signals;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class Player : MonoBehaviour
    {
        private Pool _pool;
        private SignalBus _signalBus;
        private DiContainer _container;

        private PawnActivator _activator;
        private PlayerParameters _parameters;
        private PawnCollectables _collectables;

        private ArmorFragmentsSpawner _armorFragmentsSpawner;

        private PawnBody _body;

        [Inject]
        private void Construct(Pool pool, DiContainer container, SignalBus signalBus,
            PawnActivator acitvator, PlayerParameters parameters, PawnCollectables collectables,
            ArmorFragmentsSpawner armorFragmentsSpawner)
        {
            _pool = pool;
            _signalBus = signalBus;
            _container = container;

            _container.BindInstance(parameters.PawnPartsParameters);
            _container.Bind<ISprintController>().To<PlayerKeyboardSprintController>().FromNewComponentOn(gameObject).AsSingle();

            _activator = acitvator;
            _parameters = parameters;
            _collectables = collectables;

            _armorFragmentsSpawner = armorFragmentsSpawner;
        }

        public void Initialize()
        {
            _container.InstantiateComponent<MovePawnToMouse>(gameObject);
        }

        private void Start()
        {
            _body = _container.Resolve<PawnBody>();
            _body.OnHitted += Die;

            _container.Resolve<PawnParts>().SetLayers(Layers.Player);
        }

        public void Activate(SpawnParameters spawnParameters)
        {
            _activator.Activate();
            transform.position = spawnParameters.SpawnPosition;
        }

        private void Die(PawnWeapon byWeapon)
        {
            _pool.Despawn(this);
            _armorFragmentsSpawner.SpawnArmorFragments(transform.position, _collectables.Parameters);

            _signalBus.Fire<PlayerDieSignal>(new(this));
        }
    }

    [Serializable]
    public struct PlayerParameters
    {
        public PawnPartsParameters PawnPartsParameters;
    }
}