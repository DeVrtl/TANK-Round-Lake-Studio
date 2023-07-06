using UnityEngine;
using Cinemachine;

namespace CameraAndCinemachine
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CinemachineShake : MonoBehaviour
    {
        [SerializeField] private float _shakeIntensity;
        [SerializeField] private float _shakeTime;

        private float _timer;
        private CinemachineBasicMultiChannelPerlin _multiChannelPerlin;
        private CinemachineVirtualCamera _virtualCamera;

        private void Awake()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _multiChannelPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            StopShake();
        }

        public void Shake()
        {
            _multiChannelPerlin.m_AmplitudeGain = _shakeIntensity;
            _timer = _shakeTime;
        }

        private void StopShake()
        {
            _multiChannelPerlin.m_AmplitudeGain = 0;
            _timer = 0;
        }

        private void Update()
        {
            if(_timer > 0)
            {
                _timer -= Time.deltaTime;

                if(_timer < 0)
                {
                    StopShake();
                }
            }
        }
    }
}