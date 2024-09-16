using Game.Gameplay.Pawn.Collliding;
using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn
{
    public class PawnCollectables : MonoBehaviour, IPawnActivateObject
    {
        private DiContainer _container;
        private PawnBody _body;

        public PawnCollectablesParameters Parameters;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        private void Start()
        {
            _body = _container.Resolve<PawnBody>();

            _body.OnArmored += armorFragment => Parameters.ArmorFragments++;
            _body.OnAppleEated += apple => Parameters.Apples++;
            _body.OnGoldCoinTaked += goldCoint => Parameters.GoldCoins++;
        }

        public void Activate()
        {
            Parameters = new();
        }
    }

    [Serializable]
    public struct PawnCollectablesParameters
    {
        public int ArmorFragments;
        public int Apples;
        public int GoldCoins;

        public PawnCollectablesParameters(int armorFragments = 0, int apples = 0, int goldCoins = 0)
        {
            ArmorFragments = armorFragments;
            Apples = apples;
            GoldCoins = goldCoins;
        }
    }
}