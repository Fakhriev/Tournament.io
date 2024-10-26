using UnityEngine;
using Zenject;

namespace Game.Gameplay.Pawn
{
    public class PawnActivator : MonoBehaviour
    {
        private IPawnActivateObject[] _activateObjects;
        private IPawnDeactivateObject[] _deactivateObjects;

        [Inject]
        private void Construct(IPawnActivateObject[] activateObjects, IPawnDeactivateObject[] deactivateObjects)
        {
            _activateObjects = activateObjects;
            _deactivateObjects = deactivateObjects;
        }

        public void Activate()
        {
            foreach(var activateObject in _activateObjects) 
                activateObject.Activate();
        }

        public void Deactivate()
        {
            foreach (var deactivateObject in _deactivateObjects)
                deactivateObject.Deactivate();
        }
    }

    public interface IPawnActivateObject
    {
        public void Activate();
    }

    public interface IPawnDeactivateObject
    {
        public void Deactivate();
    }
}