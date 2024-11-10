using Extensions;
using Game.Gameplay.Powers;
using Menu.Data;
using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Menu.Zenject.ScriptableObjectsInstaller
{
    [CreateAssetMenu(fileName = nameof(ShopElementsInstaller), menuName = "Installers/Shop Elements Installer")]
    public class ShopElementsInstaller : ScriptableObjectInstaller<ShopElementsInstaller>
    {
        [SerializeField, ListDrawerSettings(HideAddButton = true, HideRemoveButton = false, ShowFoldout = false)]
        private ShopPowerData[] _shopPowersData;

        public override void InstallBindings()
        {
            Container.BindInstances(_shopPowersData);
        }

        [Button]
        private void UpdatePowersArray()
        {
            var powersTypes = typeof(PowerBase).GetDerivedTypes();

            if (_shopPowersData == null)
                _shopPowersData = new ShopPowerData[0];

            var powersList = _shopPowersData.ToList();


            foreach (var powerType in powersTypes)
            {
                if(powersList.Any(p => p.PowerIdentifier.Equals(powerType.Name)) == false)
                {
                    powersList.Add(new ShopPowerData(powerType.Name));
                }
            }

            _shopPowersData = powersList.ToArray();
        }

        [Button]
        private void Clear()
        {
            _shopPowersData = new ShopPowerData[0];
        }
    }
}