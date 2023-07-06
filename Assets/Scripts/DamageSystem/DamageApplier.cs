using UnityEngine;

namespace DamageSystem
{
    public class DamageApplier : MonoBehaviour
    {
        [field: SerializeField] public float Damage { get; private set; }
    }
}