using CameraAndCinemachine;
using DamageSystem;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Health))]
    public class EnemyHandler : MonoBehaviour
    {
        [SerializeField] private CinemachineShake _cameraShake;

        private Health _enemyHealth;

        private void Awake()
        {
            _enemyHealth = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _enemyHealth.Killed += OnKilled;
        }

        private void OnDisable()
        {
            _enemyHealth.Killed -= OnKilled;
        }

        private void OnKilled()
        {
            _cameraShake.Shake();
        }
    }
}