using Game.Gameplay.Pawn.Collliding;
using Game.Gameplay.TagComponents;
using Game.Zenject.Signals;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.StateServices
{
    public class GameStatistic : MonoBehaviour, IRestartObject
    {
        private SignalBus _signalBus;
        private DiContainer _container;
        private GameTimer _gameTimer;

        private PawnBody _playerPawnBody;

        [SerializeField]
        private Statistic _statistic;

        public Statistic Value => _statistic;

        [Inject]
        private void Construct(DiContainer container, SignalBus signalBus, GameTimer gameTimer)
        {
            _signalBus = signalBus;
            _container = container;
            _gameTimer = gameTimer;
        }

        private void Start()
        {
            ResetCounts();
            _playerPawnBody = _container.Resolve<PawnBody>();

            _playerPawnBody.OnArmored += OnArmored;
            _playerPawnBody.OnAppleEated += OnAppleEated;
            _playerPawnBody.OnGoldCoinTaked += OnGoldCoinCollected;

            _signalBus.Subscribe<PlayerDieSignal>(OnPlayerDie);
            _signalBus.Subscribe<EnemyDieSignal>(OnEnemyDie);
            _signalBus.Subscribe<BossDieSignal>(OnBossDie);
            _signalBus.Subscribe<TimerEndSignal>(OnTimerEnd);
        }

        private void ResetCounts()
        {
            _statistic = new Statistic();
        }

        #region CollectingEvents

        private void OnArmored(ArmorFragment armorFragment)
        {
            _statistic.ArmorsFragmentCollected++;
        }

        private void OnAppleEated(Apple apple)
        {
            _statistic.ApplesCollected++;
        }

        private void OnGoldCoinCollected(GoldCoin goldCoin)
        {
            _statistic.GoldCoinsCollected++;
        }

        #endregion

        #region DieSignals

        private void OnPlayerDie(PlayerDieSignal playerDieSignal)
        {
            _statistic.AliveTime = Mathf.RoundToInt(_gameTimer.RoundTimePassed);
        }

        private void OnEnemyDie(EnemyDieSignal enemyDieSignal)
        {
            if (enemyDieSignal.HitSource.Owner is Player)
                _statistic.EnemyKilled++;
        }

        private void OnBossDie(BossDieSignal bossDieSignal)
        {
            if (bossDieSignal.HitSource.Owner is Player)
                _statistic.BossKilled++;
        }

        private void OnTimerEnd(TimerEndSignal timerEndSignal)
        {
            _statistic.AliveTime = Mathf.RoundToInt(_gameTimer.RoundTimePassed);
        }

        #endregion

        public void Restart()
        {
            ResetCounts();
        }

        [Serializable]
        public struct Statistic
        {
            public int ArmorsFragmentCollected;
            public int ApplesCollected;
            public int GoldCoinsCollected;

            [Space]
            public int EnemyKilled;
            public int BossKilled;
            public int AliveTime;
        }
    }
}