using Menu.Data;

namespace Menu.UI.Shop
{
    public partial class PowerShopItem
    {
        public struct SpawnParameters
        {
            public PowerShopData PowerShopData { get; private set; }

            public SpawnParameters(PowerShopData powerShopData)
            {
                PowerShopData = powerShopData;
            }
        }
    }
}