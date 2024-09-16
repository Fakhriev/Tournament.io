using Game.Gameplay.Abstracts;
using Game.Gameplay.TagComponents;
using System;

namespace Game.Gameplay.Pawn.Collliding
{
    public class PawnBody : ObjectPartBase
    {
        public Action<PawnWeapon> OnHitted;

        public Action<ArmorFragment> OnArmored;
        public Action<Apple> OnAppleEated;
        public Action<GoldCoin> OnGoldCoinTaked;

        public void Hit(PawnWeapon byWeapon)
        {
            OnHitted?.Invoke(byWeapon);
        }

        public void ArmorUp(ArmorFragment armorFragment)
        {
            OnArmored?.Invoke(armorFragment);
        }

        public void EatApple(Apple apple)
        {
            OnAppleEated?.Invoke(apple);
        }

        public void TakeGoldCoin(GoldCoin goldCoin)
        {
            OnGoldCoinTaked?.Invoke(goldCoin);
        }
    }
}