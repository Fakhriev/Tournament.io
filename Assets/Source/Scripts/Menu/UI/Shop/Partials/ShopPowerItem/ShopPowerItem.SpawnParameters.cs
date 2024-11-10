using Menu.Data;

namespace Menu.UI.Shop
{
    public partial class ShopPowerItem
    {
        public struct SpawnParameters
        {
            public ShopPowerData ShopPowerData { get; private set; }

            public SpawnParameters(ShopPowerData shopPowerData)
            {
                ShopPowerData = shopPowerData;
            }
        }
    }
}