using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.States.Interfaces;

namespace Assets.Scripts.Infrastructure.States
{
    public interface IGameStateMachine : IService
    {
        void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
        void Enter<TState>() where TState : class, IState;
    }
}