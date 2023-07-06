using static UnityEngine.InputSystem.InputAction;
using CameraAndCinemachine;
using System.Collections;
using UnityEngine;
using Zenject;
using Services;
using Bullet;
using Configs;

namespace Player
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private BulletMover _bullet;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private ObjectPool _bulletPool;
        [SerializeField] private ParticleSystem _shootEffect;
        [SerializeField] private CinemachineShake _cameraShake;

        private Shooter _shooter;
        private Coroutine _reloadProcess;
        private PlayerConfig _config;

        private bool _isCanShoot = true;

        private void Awake()
        {
            _shooter = new Shooter();
            _shooter.Enable();
            _shooter.Main.Shoot.performed += OnShootButtonDownPressed;
            _bulletPool.Init(_bullet.gameObject);
        }

        [Inject]
        private void Init(PlayerConfig settings)
        {
            _config = settings;
        }

        private void OnShootButtonDownPressed(CallbackContext context)
        {
            if (!_isCanShoot)
            {
                return;
            }

            if (_bulletPool.TryGetObject(out GameObject bullet))
            {
                bullet.SetActive(true);
                bullet.transform.position = _shootPoint.position;
                bullet.transform.rotation = transform.rotation;
                _shootEffect.Play();
                _cameraShake.Shake();
            }

            _isCanShoot = false;
            _reloadProcess = StartCoroutine(ReloadTimerProcess());
        }

        private void OnDestroy()
        {
            _shooter.Disable();
            StopCoroutine(_reloadProcess);
        }

        private IEnumerator ReloadTimerProcess()
        {
            float timer = 0f;
            while (timer < _config.RealodSpeed)
            {
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            _isCanShoot = true;
        }
    }
}