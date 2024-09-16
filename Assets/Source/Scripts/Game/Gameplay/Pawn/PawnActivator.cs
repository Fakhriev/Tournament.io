using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn
{
    public class PawnActivator : MonoBehaviour
    {
        private IPawnActivateObject[] _activateObjects;

        [Inject]
        private void Construct(IPawnActivateObject[] activateObjects)
        {
            _activateObjects = activateObjects;
        }

        public void Activate()
        {
            foreach(var activateObject in _activateObjects) 
                activateObject.Activate();
        }
    }

    public interface IPawnActivateObject
    {
        public void Activate();
    }
}