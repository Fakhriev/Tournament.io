using Extensions;
using Game.Gameplay.Utility.Extensions;
using Redcode.Extensions;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Game.Gameplay.Powers.BehaviorComponents
{
    public class RandomPower : PowerBase
    {
        private RandomPowerParameters _parameters;
        private PowerBase _randomPower;

        private IEnumerable<Type> BannedPowerTypes => _parameters.BannedPowers.Select(bp => Type.GetType(bp));

        [Inject]
        private void Construct(RandomPowerParameters parameters)
        {
            _parameters = parameters;
        }

        private void Start()
        {
            var randomPowerType = GetPowerBaseDerivedTypes().Except(BannedPowerTypes).GetRandomElement();
            _randomPower = _container.InstantiateComponent(randomPowerType, gameObject) as PowerBase;
        }

        private void OnDestroy()
        {
            Destroy(_randomPower);
        }

        public static IEnumerable<Type> GetPowerBaseDerivedTypes()
        {
            return typeof(PowerBase).GetDerivedTypes();
        }
    }

    [Serializable]
    public struct RandomPowerParameters
    {
        [ValueDropdown(nameof(GetValues))]
        public string[] BannedPowers;

        private IEnumerable GetValues()
        {
            return RandomPower
                .GetPowerBaseDerivedTypes()
                .Select(type => new ValueDropdownItem<string>(type.Name, type.FullName));
        }
    }
}