using Game.Gameplay.Spawners;
using Game.Gameplay.TagComponents;
using Game.UI;
using Game.Zenject.Signals;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.StateServices
{
    public class GameEnder : MonoBehaviour
    {
        private SignalBus _signalBus;

        private Boss.Pool _bossPool;
        private Enemy.Pool _enemyPool;
        private BossSpawner _bossSpawner;

        private GameCanvas _gameCanvas;

        [Inject]
        private void Construct(SignalBus signalBus, Boss.Pool bossPool, Enemy.Pool enemyPool, BossSpawner bossSpawner, GameCanvas gameCanvas)
        {
            _signalBus = signalBus;

            _bossPool = bossPool;
            _enemyPool = enemyPool;
            _bossSpawner = bossSpawner;

            _gameCanvas = gameCanvas;
        }

        private void Start()
        {
            _signalBus.Subscribe<PlayerDieSignal>(OnPlayerDie);
            _signalBus.Subscribe<EnemyDieSignal>(OnEnemyDie);
            _signalBus.Subscribe<BossDieSignal>(OnBossDie);
            _signalBus.Subscribe<TimerEndSignal>(OnTimerEnd);
        }

        private void OnPlayerDie(PlayerDieSignal playerDieSignal)
        {
            GameEnd(GameEndType.Lose);
        }

        private void OnEnemyDie(EnemyDieSignal enemyDieSignal)
        {
            if (IsEveryEnemyKilled())
                GameEnd(GameEndType.Victory);
        }

        private void OnBossDie(BossDieSignal bossDieSignal)
        {
            if(IsEveryEnemyKilled())
                GameEnd(GameEndType.Victory);
        }

        private void OnTimerEnd(TimerEndSignal timerEndSignal)
        {
            GameEnd(GameEndType.Tie);
        }

        private bool IsEveryEnemyKilled()
        {
            return _enemyPool.NumActive == 0 && _bossSpawner.BossSpawned && _bossPool.NumActive == 0;
        }

        private void GameEnd(GameEndType gameEndType)
        {
            _signalBus.Fire(new GameEndSignal(gameEndType));

            _gameCanvas.ActivateGameEnd(gameEndType);

            _signalBus.Fire(new LateGameEndSignal(gameEndType));
        }
    }
}