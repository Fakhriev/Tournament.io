using Game.Gameplay.GameServices;
using Game.Zenject.Signals;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.StateServices
{
    public class GameRewardsGiver : MonoBehaviour
    {
        private SignalBus _signalBus;
        private SoftCurrency _softCurrency;
        private GameRewardsCounter _rewardCounter;

        [Inject]
        private void Construct(SignalBus signalBus, SoftCurrency softCurrency, GameRewardsCounter rewardsCounter)
        {
            _signalBus = signalBus;
            _softCurrency = softCurrency;
            _rewardCounter = rewardsCounter;
        }

        private void Start()
        {
            _signalBus.Subscribe<LateGameEndSignal>(OnGameEnd);
        }

        private void OnGameEnd(LateGameEndSignal lateGameEndSignal)
        {
            _softCurrency.Add(_rewardCounter.TotalGameSoftCurrency);
        }
    }
}