using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Game/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public float HullSpeed { get; private set; }
        [field: SerializeField] public float ReloadTime { get; private set; }
        [field: SerializeField] public float FovRadius { get; private set; }

        private void OnValidate()
        {
            HullSpeed = Mathf.Clamp(HullSpeed, 0, float.MaxValue);
            ReloadTime = Mathf.Clamp(ReloadTime, 0, float.MaxValue);
            FovRadius = Mathf.Clamp(FovRadius, 0, float.MaxValue);
        }
    }
}