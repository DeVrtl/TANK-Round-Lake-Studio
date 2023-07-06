using UnityEngine;

namespace CameraAndCinemachine
{
    public class FaceCamera : MonoBehaviour
    {
        private Transform _mainCameraTransform;

        private void Awake()
        {
            _mainCameraTransform = Camera.main.transform;
        }

        private void LateUpdate()
        {
            transform.forward = -_mainCameraTransform.forward;
        }
    }
}