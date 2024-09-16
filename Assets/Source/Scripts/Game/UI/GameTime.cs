using Game.Gameplay.Stage;
using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.UI
{
    public class GameTime : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI tmpTimer;

        private GameTimer _gameTimer;

        [Inject]
        private void Construct(GameTimer gameTimer)
        {
            _gameTimer = gameTimer;
        }

        private void LateUpdate()
        {
            TimeSpan gameTimeSpan = TimeSpan.FromSeconds(_gameTimer.RoundTimeLeft);
            tmpTimer.text = gameTimeSpan.ToString(@"mm\:ss");
        }
    }
}