using Redcode.Extensions;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Gameplay.Utility
{
    public static class TransformExtensions
    {
        public static Transform GetRandomElementBeyondCamera(this IEnumerable<Transform> enumerable, Vector3 boundSize, Camera camera = null)
        {
            if (camera == null)
                camera = Camera.main;

            List<Transform> beyondCameraTransforms = new List<Transform>();
            Plane[] cameraPlanes = GeometryUtility.CalculateFrustumPlanes(camera);

            foreach (var transform in enumerable)
            {
                Bounds bounds = new Bounds(transform.transform.position, boundSize);

                if (GeometryUtility.TestPlanesAABB(cameraPlanes, bounds) == false)
                    beyondCameraTransforms.Add(transform);
            }

            return beyondCameraTransforms.GetRandomElement();
        }
    }
}
