using DamageSystem;
using UnityEngine;

namespace Player
{
    public class PlayerLifeChecker : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Health _health;

        private void Awake()
        {
            if (_player.gameObject.activeSelf == true)
            {
                Time.timeScale = 1f;
            }
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
            Time.timeScale = 0f;
        }
    }
}