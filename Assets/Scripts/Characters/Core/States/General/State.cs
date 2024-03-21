namespace SublimeFury
{
    public abstract class State
    {
        public abstract void EnterState(State_Machine stateMachine);

        public abstract void UpdateState(State_Machine stateMachine);

        public abstract void ExitState(State_Machine stateMachine);
    }
}