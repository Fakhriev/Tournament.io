using UnityEngine;
using Zenject;
using Services;
using Game.Zenject.Signals;

namespace Game.Gameplay.StateServices
{
    public class GameRewardsGiver : MonoBehaviour
    {
        private SignalBus _signalBus;
        private SoftCurrencyService _softCurrencyService;
        private GameRewardsCounter _rewardCounter;

        [Inject]
        private void Construct(SignalBus signalBus, SoftCurrencyService softCurrencyService, GameRewardsCounter rewardsCounter)
        {
            _signalBus = signalBus;
            _softCurrencyService = softCurrencyService;
            _rewardCounter = rewardsCounter;
        }

        private void Start()
        {
            _signalBus.Subscribe<LateGameEndSignal>(OnGameEnd);
        }

        private void OnGameEnd(LateGameEndSignal lateGameEndSignal)
        {
            _softCurrencyService.Add(_rewardCounter.TotalGameSoftCurrency);
        }
    }
}