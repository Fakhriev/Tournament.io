using Game.Gameplay.Abstracts;
using Game.Gameplay.Behavior;
using Game.Gameplay.Pawn;
using Game.Gameplay.Pawn.Collliding;
using Game.Gameplay.Pawn.Movement;
using Game.Gameplay.Pawn.Movement.Sprint.SprintControll;
using Game.Gameplay.Spawners;
using Game.Zenject.Signals;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class Boss : MonoBehaviour, IPawnCharacter
    {
        private Pool _pool;
        private SignalBus _signalBus;
        private DiContainer _container;

        private PawnMovement _movement;
        private PawnActivator _activator;
        private PawnCollectables _collectables;
        private BossParameters _parameters;

        private GoldCoinsSpawner _goldCoinsSpawner;
        private ArmorFragmentsSpawner _armorFragmentsSpawner;

        private PawnBody _body;
        private EnemyBehavior _enemyBehavior;

        public GameObject PawnGameObject => gameObject;

        public DiContainer PawnContainer => _container;

        [Inject]
        private void Construct(Pool pool, DiContainer container, SignalBus signalBus,
            PawnMovement movement, PawnActivator activator, PawnCollectables collectables, BossParameters parameters,
            GoldCoinsSpawner goldCoinsSpawner, ArmorFragmentsSpawner armorFragmentsSpawner)
        {
            _pool = pool;
            _signalBus = signalBus;
            _container = container;

            _container.BindInstance(parameters.PawnPartsParameters);
            _container.Bind<IPawnCharacter>().To<Boss>().FromInstance(this);
            _container.Bind<ISprintController>().To<ManualSprintController>().FromNew().AsSingle();

            _movement = movement;
            _activator = activator;
            _collectables = collectables;
            _parameters = parameters;

            _goldCoinsSpawner = goldCoinsSpawner;
            _armorFragmentsSpawner = armorFragmentsSpawner;
        }

        private void Start()
        {
            _body = _container.Resolve<PawnBody>();
            _body.OnHitted += OnHit;

            _enemyBehavior = _container.InstantiateComponent<EnemyBehavior>(gameObject);
            _container.Resolve<PawnParts>().SetLayers(Layers.Boss);
        }

        public void Activate(SpawnParameters spawnParameters)
        {
            _activator.Activate();
            transform.position = spawnParameters.SpawnPosition;

            StartCoroutine(SetCollectables());
        }

        private IEnumerator SetCollectables()
        {
            yield return null;

            int armorFragments = UnityEngine.Random.Range(_parameters.MinimalCollectablesActivateAmount.ArmorFragments, _parameters.MaximalCollectablesActivateAmount.ArmorFragments + 1);
            int goldCoins = UnityEngine.Random.Range(_parameters.MinimalCollectablesActivateAmount.GoldCoins, _parameters.MaximalCollectablesActivateAmount.GoldCoins);

            for (int i = 0; i < armorFragments; i++)
                _body.ArmorUp(null);

            for (int i = 0; i < goldCoins; i++)
                _body.TakeGoldCoin(null);
        }

        private void OnHit(IHitSource hitSource)
        {
            if (hitSource.Owner is Enemy || hitSource.Owner.PawnGameObject.Equals(gameObject))
                return;

            _pool.Despawn(this);
            _activator.Deactivate();

            _goldCoinsSpawner.SpawnCoins(transform.position, _collectables.Parameters);
            _armorFragmentsSpawner.SpawnArmorFragments(transform.position, _collectables.Parameters);

            _signalBus.Fire<BossDieSignal>(new(this));
        }
    }

    [Serializable]
    public struct BossParameters
    {
        public PawnPartsParameters PawnPartsParameters;

        [Space]
        public PawnCollectablesParameters MinimalCollectablesActivateAmount;
        public PawnCollectablesParameters MaximalCollectablesActivateAmount;
    }
}