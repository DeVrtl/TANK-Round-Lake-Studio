namespace Enemy.Turret
{
    public class EnemyTurretState
    {
        public EnemyTurretStateMachine StateMachine;
        public EnemyTurretStateMachineContext Context;

        public void Initialize(EnemyTurretStateMachine stateMachine, EnemyTurretStateMachineContext context)
        {
            StateMachine = stateMachine;
            Context = context;
        }

        public virtual void EnterState() { }
        public virtual void UpdateState() { }
    }
}