using DamageSystem;
using UnityEngine;

namespace Bullet
{
    [RequireComponent(typeof(DamageApplier))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _hitEffect;
        public BulletMover Mover { get; private set; }

        private DamageApplier _damageApplier;

        private void Awake()
        {
            _damageApplier = GetComponent<DamageApplier>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Health health))
            {
                health.Value -= _damageApplier.Damage;
            }

            Instantiate(_hitEffect, transform.position, Quaternion.identity);

            gameObject.SetActive(false);
        }
    }
}