
namespace Assets.Scripts.Infrastructure.States.Interfaces
{
    public interface IPayloadState<T> : IExitableState
    {
        void Enter(T payload);
    }
}
