using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float RealodSpeed { get; private set; }
        [field: SerializeField] public float TurretRotationSpeed { get; private set; }

        private void OnValidate()
        {
            RotationSpeed = Mathf.Clamp(RotationSpeed, 0, float.MaxValue);
            Speed = Mathf.Clamp(Speed, 0, float.MaxValue);
            RealodSpeed = Mathf.Clamp(RealodSpeed, 0, float.MaxValue);
            TurretRotationSpeed = Mathf.Clamp(TurretRotationSpeed, 0, float.MaxValue);
        }
    }
}