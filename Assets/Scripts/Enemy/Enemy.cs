using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _boomEffect;

        public event UnityAction Killed;

        private void OnDisable()
        {
            Killed?.Invoke();
            Instantiate(_boomEffect, transform.position, Quaternion.identity);
            _boomEffect.Play();
        }
    }
}

