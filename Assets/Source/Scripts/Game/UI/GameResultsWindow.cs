using Game.Gameplay.StateServices;
using System;
using System.Text;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class GameResultsWindow : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _tmpResults;

        private GameStatistic _gameStatistic;
        private GameRewardsCounter _gameRewardsCounter;
        private GameRewardsCounter.Parameters _gameResultParameters;

        [Inject]
        private void Construct(GameRewardsCounter gameResults, GameStatistic gameStatistic, GameRewardsCounter.Parameters gameResultParameters)
        {
            _gameRewardsCounter = gameResults;
            _gameStatistic = gameStatistic;
            _gameResultParameters = gameResultParameters;
        }

        public void Show(GameEndType gameEndType)
        {
            var sb = new StringBuilder();
            var statistic = _gameStatistic.Value;

            sb.AppendLine($"Armors: [{statistic.ArmorsFragmentCollected}] x[{_gameResultParameters.ArmorsFragmentFactor}]");
            sb.AppendLine($"Apples: [{statistic.ApplesCollected}] x[{_gameResultParameters.ApplesFactor}]");
            sb.AppendLine($"Gold Coins: [{statistic.GoldCoinsCollected}] x[{_gameResultParameters.GoldCoinsFactor}]");

            sb.AppendLine($"Enemies: [{statistic.EnemyKilled}] x[{_gameResultParameters.EnemiesFactor}]");
            sb.AppendLine($"Bosses: [{statistic.BossKilled}] x[{_gameResultParameters.BossFactor}]");
            sb.AppendLine($"Alive Time: [{statistic.AliveTime}] x[{_gameResultParameters.AliveFactor}]");

            sb.AppendLine($"Game End: [{gameEndType}] x[{_gameResultParameters.GetGameEndTypeFactor(gameEndType)}]");
            sb.AppendLine($"Total: [{_gameRewardsCounter.TotalGameSoftCurrency}]");
            
            _tmpResults.text = sb.ToString();
        }
    }
}