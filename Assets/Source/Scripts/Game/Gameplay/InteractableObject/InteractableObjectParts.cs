using System;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.InteractableObject
{
    public class InteractableObjectParts : MonoBehaviour, IInitializable
    {
        private DiContainer _container;
        private InteractableObjectPartsParameters _parameters;

        private InteractableObjectBody _body;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _parameters = _container.Resolve<InteractableObjectPartsParameters>();
            InstallBodyParts();
        }

        private void InstallBodyParts()
        {
            _body = _container.InstantiatePrefabForComponent<InteractableObjectBody>(_parameters.InteractableObjectBody, transform);
            _body.SetSortingOrder(_parameters.BodySortingOrder);
            _container.BindInstance(_body);
        }
    }

    [Serializable]
    public struct InteractableObjectPartsParameters
    {
        public InteractableObjectBody InteractableObjectBody;
        public int BodySortingOrder;
    }
}