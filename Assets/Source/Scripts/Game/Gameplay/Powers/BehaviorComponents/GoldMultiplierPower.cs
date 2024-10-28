using Game.Gameplay.Pawn;
using Game.Gameplay.Pawn.Collliding;
using Game.Gameplay.TagComponents;
using System;
using Zenject;

namespace Game.Gameplay.Powers.BehaviorComponents
{
    public class GoldMultiplierPower : PowerBase
    {
        private GoldMultiplierPowerParameters _parameters;

        private PawnCollectables _pawnCollectabled;
        private PawnBody _pawnBody;

        [Inject]
        private void Construct(GoldMultiplierPowerParameters parameters)
        {
            _parameters = parameters;
        }

        private void Start()
        {
            _pawnBody = _container.Resolve<PawnBody>();
            _pawnBody.OnGoldCoinTaked += OnGoldCoinTaked;

            _pawnCollectabled = _container.Resolve<PawnCollectables>();
        }

        private void OnGoldCoinTaked(GoldCoin goldCoin)
        {
            _pawnCollectabled.Parameters.GoldCoins += _parameters.MultiplyValue - 1;
        }

        private void OnDestroy()
        {
            _pawnBody.OnGoldCoinTaked -= OnGoldCoinTaked;
        }
    }

    [Serializable]
    public struct GoldMultiplierPowerParameters
    {
        public int MultiplyValue;
    }
}