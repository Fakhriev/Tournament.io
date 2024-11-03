using Game.UI;
using Game.Zenject.Signals;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.StateServices
{
    public class GameRewardsCounter : MonoBehaviour
    {
        private SignalBus _signalBus;
        private GameStatistic _gameStatistic;
        private Parameters _parameters;

        [field: SerializeField]
        public int TotalGameSoftCurrency { get; private set; }

        [Inject]
        private void Construct(SignalBus signalBus, GameStatistic gameStatistic, Parameters parameters)
        {
            _signalBus = signalBus;
            _gameStatistic = gameStatistic;
            _parameters = parameters;
        }

        private void Start()
        {
            _signalBus.Subscribe<GameEndSignal>(OnGameEnd);
        }

        private void OnGameEnd(GameEndSignal gameEndSignal)
        {
            var statistic = _gameStatistic.Value;

            float armorsReward= statistic.ArmorsFragmentCollected * _parameters.ArmorsFragmentFactor;
            float applesReward = statistic.ApplesCollected * _parameters.ApplesFactor;
            float goldCoinsReward = statistic.GoldCoinsCollected * _parameters.GoldCoinsFactor;

            float enemiesReward = statistic.EnemyKilled * _parameters.EnemiesFactor;
            float bossesReward = statistic.BossKilled * _parameters.BossFactor;
            float aliveTimeReward = statistic.AliveTime * _parameters.AliveFactor;

            float gameEndTypeFactor = _parameters.GetGameEndTypeFactor(gameEndSignal.GameEndType);
            float result = (armorsReward + applesReward + goldCoinsReward + enemiesReward + bossesReward + aliveTimeReward) * gameEndTypeFactor;

            const float roundingCorrectionDelta = 0.01f;
            TotalGameSoftCurrency = Mathf.RoundToInt(result + roundingCorrectionDelta);
        }

        [Serializable]
        public struct Parameters
        {
            public float ArmorsFragmentFactor;
            public float ApplesFactor;
            public float GoldCoinsFactor;

            public float EnemiesFactor;
            public float BossFactor;
            public float AliveFactor;

            public float VictoryFactor;
            public float LoseFactor;
            public float TieFactor;

            public float GetGameEndTypeFactor(GameEndType gameEndType)
            {
                return gameEndType switch
                {
                    GameEndType.Victory => VictoryFactor,
                    GameEndType.Lose => LoseFactor,
                    GameEndType.Tie => TieFactor,
                    _ => 0,
                };
            }
        }
    }
}