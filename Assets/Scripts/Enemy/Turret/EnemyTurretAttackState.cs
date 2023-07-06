using UnityEngine;

namespace Enemy.Turret
{
    public class EnemyTurretAttackState : EnemyTurretState
    {
        public override void UpdateState()
        {
            if (Context.FOV.Target != null)
            {
                Vector3 direction = Context.FOV.Target.position - Context.transform.position;
                Context.transform.rotation = Quaternion.LookRotation(Vector3.back, direction);

                Context.Shooter.enabled = true;
            }
            else
            {
                Context.Shooter.enabled = false;
                StateMachine.SwitchState(StateMachine.Idle);
            }
        }
    }
}
