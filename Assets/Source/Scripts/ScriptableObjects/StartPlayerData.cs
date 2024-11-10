using Data;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(StartPlayerData), menuName = "Data/Start Player Data")]
    public class StartPlayerData : ScriptableObject
    {
        [field: SerializeField]
        public PlayerData PlayerData { get; private set; }
    }
}