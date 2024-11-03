using Game.Gameplay.GameServices;
using UnityEngine;
using Zenject;

namespace Game.Zenject
{
    public class GameServicesInstaller : MonoInstaller
    {
        [SerializeField]
        private SoftCurrency _softCurrency;

        public override void InstallBindings()
        {
            _softCurrency = new SoftCurrency();
            Container.BindInstances(_softCurrency);
        }
    }
}