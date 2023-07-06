using DamageSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Slider _slider;
        [SerializeField] private float _speed;

        private void OnEnable()
        {
            _health.Hitted += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.Hitted -= OnHealthChanged;
        }

        private void Start()
        {
            _slider.maxValue = _health.Value;
            _slider.value = _health.Value;
        }

        private void OnHealthChanged(float health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _speed * Time.deltaTime);
        }
    }
}