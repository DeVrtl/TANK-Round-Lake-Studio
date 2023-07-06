using UnityEngine;
using Zenject;
using Services;
using Configs;
using CameraAndCinemachine;

namespace Enemy
{
    public class EnemyShooter : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private ObjectPool _bulletPool;
        [SerializeField] private ParticleSystem _shootEffect;
        [SerializeField] private CinemachineShake _cameraShake;

        private EnemyConfig _config;
        private float _elapsedTime = 0;

        [Inject]
        private void Init(EnemyConfig config)
        {
            _config = config;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _config.ReloadTime)
            {
                _elapsedTime = 0;


                if (_bulletPool.TryGetObject(out GameObject bullet))
                {
                    bullet.SetActive(true);
                    bullet.transform.position = _shootPoint.position;
                    bullet.transform.rotation = transform.rotation;
                    _shootEffect.Play();
                    _cameraShake.Shake();
                }
            }
        }
    }
}