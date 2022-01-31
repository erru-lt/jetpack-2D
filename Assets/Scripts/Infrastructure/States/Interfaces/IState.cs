namespace Assets.Scripts.Infrastructure.States.Interfaces
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}
