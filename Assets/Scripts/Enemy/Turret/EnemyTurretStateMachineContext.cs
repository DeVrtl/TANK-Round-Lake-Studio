using UnityEngine;

namespace Enemy.Turret
{
    public class EnemyTurretStateMachineContext : MonoBehaviour
    {
        [field: SerializeField] public EnemyFOV FOV;
        [field: SerializeField] public EnemyShooter Shooter;
    }
}