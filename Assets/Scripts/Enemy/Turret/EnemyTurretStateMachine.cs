using UnityEngine;

namespace Enemy.Turret
{
    public class EnemyTurretStateMachine : MonoBehaviour
    {
        [field: SerializeField] public EnemyTurretStateMachineContext Context;

        public EnemyTurretState CurrentState { get; private set; }
        public EnemyTurretIdleState Idle { get; private set; } = new();
        public EnemyTurretAttackState Attack { get; private set; } = new();

        private void Awake()
        {
            Idle.Initialize(this, Context);
            Attack.Initialize(this, Context);

            SwitchState(Idle);
        }

        public void Update()
        {
            CurrentState.UpdateState();
        }

        public void SwitchState(EnemyTurretState state)
        {
            CurrentState = state;
            CurrentState.EnterState();
        }
    }
}