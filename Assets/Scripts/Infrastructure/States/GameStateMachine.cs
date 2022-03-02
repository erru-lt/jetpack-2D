using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.SaveLoadService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.States.Interfaces;
using Assets.Scripts.UI.Factory;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        public Dictionary<Type, IExitableState> _states;

        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services),
                [typeof(LoadProgressState)] = new LoadProgressState(this, services.Service<IProgressService>(), services.Service<ISaveLoadService>()),
                [typeof(MainMenuState)] = new MainMenuState(sceneLoader, services.Service<IUIFactory>()),
                [typeof(SelectLevelState)] = new SelectLevelState(sceneLoader, services.Service<IUIFactory>()),
                [typeof(InventoryState)] = new InventoryState(sceneLoader, services.Service<IUIFactory>()),
                [typeof(LoadLevelState)] = new LoadLevelState(sceneLoader, services.Service<IGameFactory>(), services.Service<IUIFactory>(), services.Service<IStaticDataService>()),
                [typeof(EndLevelState)] = new EndLevelState(services.Service<IUIFactory>()),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}
