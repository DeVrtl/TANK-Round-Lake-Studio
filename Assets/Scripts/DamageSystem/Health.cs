using UnityEngine;
using UnityEngine.Events;

namespace DamageSystem
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _value;

        public float Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Hitted?.Invoke(value);
                if (value <= 0)
                {
                    _value = 0;
                    Killed?.Invoke();
                    gameObject.SetActive(false);
                }
            }
        }

        public event UnityAction<float> Hitted;
        public event UnityAction Killed;
    }
}