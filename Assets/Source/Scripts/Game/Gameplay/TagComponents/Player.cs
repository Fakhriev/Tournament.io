using Game.Gameplay.Abstracts;
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
    public partial class Player : MonoBehaviour, IPawnCharacter
    {
        private Pool _pool;
        private SignalBus _signalBus;
        private DiContainer _container;
        private PawnActivator _activator;
        private PlayerParameters _parameters;
        private PawnCollectables _collectables;

        private ArmorFragmentsSpawner _armorFragmentsSpawner;

        private PawnBody _body;

        public GameObject PawnGameObject => gameObject;

        public DiContainer PawnContainer => _container;

        [Inject]
        private void Construct(Pool pool, DiContainer container, SignalBus signalBus,
            PawnActivator acitvator, PlayerParameters parameters, PawnCollectables collectables,
            ArmorFragmentsSpawner armorFragmentsSpawner)
        {
            _pool = pool;
            _signalBus = signalBus;
            _container = container;

            _container.BindInstance(parameters.PawnPartsParameters);
            _container.Bind<IPawnCharacter>().To<Player>().FromInstance(this);
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
            _body.OnHitted += OnHit;
            _container.Resolve<PawnParts>().SetLayers(Layers.Player);
        }

        public void Activate(SpawnParameters spawnParameters)
        {
            _activator.Activate();
            transform.position = spawnParameters.SpawnPosition;
        }

        private void OnHit(IHitSource hitSource)
        {
            if (hitSource.Owner.PawnGameObject.Equals(gameObject))
                return;

            _pool.Despawn(this);
            _activator.Deactivate();

            _armorFragmentsSpawner.SpawnArmorFragments(transform.position, _collectables.Parameters);
            _signalBus.Fire<PlayerDieSignal>(new(this));
        }

        [ContextMenu("Hit By Boss")]
        private void HitByBoss()
        {
            OnHit(FindObjectOfType<Boss>(true).gameObject.GetComponentInChildren<PawnWeapon>(true));
        }
    }

    [Serializable]
    public struct PlayerParameters
    {
        public PawnPartsParameters PawnPartsParameters;
    }
}