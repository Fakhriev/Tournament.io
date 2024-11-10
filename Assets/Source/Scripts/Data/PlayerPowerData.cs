using System;

namespace Data
{
    [Serializable]
    public partial class PlayerPowerData
    {
        public string identifier;
        public State state;

        public PlayerPowerData(string identifier, State state = State.Locked)
        {
            this.identifier = identifier;
            this.state = state;
        }
    }
}