using Game.Gameplay.Utility;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Gameplay.TagComponents
{
    public partial class Marker : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] 
        private Image _image;

        private Pool _pool;
        private GameObject _target;
        private MarkerParameters _parameters;

        private Camera _maincamera;
        private string _defaultName;
        private RectTransform _rectTransform;

        private Vector3 _targetViewportPoint;
        private Vector3 _targetScreenPoint;

        [Inject]
        private void Construct(Pool pool, MarkerParameters parameters)
        {
            _pool = pool;
            _parameters = parameters;
        }

        public void Initialize()
        {
            _maincamera = Camera.main;
            _defaultName = gameObject.name;
            _rectTransform = (RectTransform)transform;
        }

        public void Activate(SpawnParameters spawnParameters)
        {
            _target = spawnParameters.Target;
            _image.color = spawnParameters.Color;
            gameObject.name = _defaultName.Replace(Constants.IndexPlace, _target.name);
        }

        private void Update()
        {
            _targetViewportPoint = _maincamera.WorldToViewportPoint(_target.transform.position);

            if(_target.gameObject.activeSelf == false)
            {
                Deactivate();
                return;
            }

            if (IsTargetOnScreen())
            {
                _image.gameObject.SetActive(false);
                return;
            }

            SetOnScreenPosition();
        }

        private bool IsTargetOnScreen()
        {
            return _targetViewportPoint.x >= 0f && _targetViewportPoint.x <= 1f && _targetViewportPoint.y >= 0f && _targetViewportPoint.y <= 1f; 
        }

        private void SetOnScreenPosition()
        {
            _image.gameObject.SetActive(true);

            _targetViewportPoint.x = Mathf.Clamp01(_targetViewportPoint.x);
            _targetViewportPoint.y = Mathf.Clamp01(_targetViewportPoint.y);

            _targetScreenPoint = _maincamera.ViewportToScreenPoint(_targetViewportPoint);
            _targetScreenPoint.z = 0f;
            _rectTransform.anchoredPosition = _targetScreenPoint - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f);
        }

        private void Deactivate()
        {
            _pool.Despawn(this);
        }
    }

    [Serializable]
    public struct MarkerParameters
    {

    }
}
