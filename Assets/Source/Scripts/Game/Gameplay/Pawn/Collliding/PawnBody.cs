using Game.Gameplay.Abstracts;
using Game.Gameplay.TagComponents;
using System;
using Zenject;

namespace Game.Gameplay.Pawn.Collliding
{
    public class PawnBody : ObjectPartBase
    {
        private IPawnCharacter _pawnCharacter;
        public IPawnCharacter Owner => _pawnCharacter;

        public Action<IHitSource> OnHitted;

        public Action<Apple> OnAppleEated;
        public Action<ArmorFragment> OnArmored;
        public Action<GoldCoin> OnGoldCoinTaked;

        [Inject]
        private void Construct(IPawnCharacter pawnCharacter)
        {
            _pawnCharacter = pawnCharacter;
        }

        public void Hit(IHitSource hitSource)
        {
            OnHitted?.Invoke(hitSource);
        }

        public void EatApple(Apple apple)
        {
            OnAppleEated?.Invoke(apple);
        }

        public void ArmorUp(ArmorFragment armorFragment)
        {
            OnArmored?.Invoke(armorFragment);
        }

        public void TakeGoldCoin(GoldCoin goldCoin)
        {
            OnGoldCoinTaked?.Invoke(goldCoin);
        }
    }
}