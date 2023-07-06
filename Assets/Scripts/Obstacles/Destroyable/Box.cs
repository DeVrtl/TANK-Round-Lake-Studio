using DamageSystem;
using UnityEngine;
using CameraAndCinemachine;

namespace Obstacles.Destroyable
{
    [RequireComponent(typeof(Health))]
    public class Box : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _boomEffect;
        [SerializeField] private CinemachineShake _cameraShake;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.Killed += OnKilled;
        }

        private void OnDisable()
        {
            _health.Killed -= OnKilled;
        }

        private void OnKilled()
        {
            ParticleSystem boomEffect = Instantiate(_boomEffect, transform.position, Quaternion.identity);
            boomEffect.Play();
            _cameraShake.Shake();
        }
    }
}