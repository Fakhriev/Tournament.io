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
        private PowerShopData[] _powersShopData;

        public override void InstallBindings()
        {
            Container.BindInstances(_powersShopData);
        }

        [Button]
        private void UpdatePowersArray()
        {
            var powersTypes = typeof(PowerBase).GetDerivedTypes();

            if (_powersShopData == null)
                _powersShopData = new PowerShopData[0];

            var powersList = _powersShopData.ToList();


            foreach (var powerType in powersTypes)
            {
                if(powersList.Any(p => p.PowerIdentifier.Equals(powerType.Name)) == false)
                {
                    powersList.Add(new PowerShopData(powerType.Name));
                }
            }

            _powersShopData = powersList.ToArray();
        }

        [Button]
        private void Clear()
        {
            _powersShopData = new PowerShopData[0];
        }
    }
}