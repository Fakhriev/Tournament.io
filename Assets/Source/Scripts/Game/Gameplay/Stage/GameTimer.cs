using Assets.Source.Scripts.Game.Gameplay.Stage;
using Game.Zenject.Signals;
using Redcode.Extensions;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Stage
{
    public class GameTimer : MonoBehaviour, IRestartObject
    {
        private SignalBus _signalBus;
        private GameTimerParameters _parameters;

        private float _timeLeft;
        private bool _timerEnded;

        public float RoundTimeLeft => _timeLeft;
        public float RoundTimePassed => _parameters.RoundTime - _timeLeft;

        [Inject]
        private void Construct(SignalBus signalBus, GameTimerParameters parameters)
        {
            _signalBus = signalBus;
            _parameters = parameters;
        }

        private void Start()
        {
            StartTimer();
        }

        private void StartTimer()
        {
            _timeLeft = _parameters.RoundTime;
            _timerEnded = false;
        }

        private void Update()
        {
            if (_timerEnded)
                return;

            _timeLeft -= Time.deltaTime;
            _timeLeft = Mathf.Clamp(_timeLeft, 0, _parameters.RoundTime);

            if (_timeLeft.Approximately(0f))
                TimerEnd();
        }

        private void TimerEnd()
        {
            _timeLeft = 0f;
            _timerEnded = true;
            _signalBus.Fire<TimerEndSignal>();
        }

        public void Restart()
        {
            StartTimer();
        }
    }

    [Serializable]
    public struct GameTimerParameters
    {
        public float RoundTime;
    }
}