using UnityEngine;

namespace Enemy.Turret
{
    public class EnemyTurretIdleState : EnemyTurretState
    {
        public override void UpdateState()
        {
            if (Context.FOV.Target != null)
            {
                StateMachine.SwitchState(StateMachine.Attack);
            }
        }
    }
}