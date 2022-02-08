using Assets.Scripts.Infrastructure.Services.InputService;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.SaveLoadService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.States.Interfaces;
using System;

namespace Assets.Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private GameStateMachine _gameStateMachine;
        private AllServices _services;
        private SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, AllServices services, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _services = services;
            _sceneLoader = sceneLoader;

            RegisterServices();
        }

        public void Enter()
        {
            OnLoaded();
        }

        public void Exit()
        {

        }

        private void RegisterServices()
        {
            RegisterInputService();
            RegisterProgressService();
            RegisterSaveLoadService();
        }

        private void RegisterInputService() => 
            _services.RegisterService<IInputService>(new InputService());

        private void RegisterProgressService() => 
            _services.RegisterService<IProgressService>(new ProgressService());

        private void RegisterSaveLoadService() => 
            _services.RegisterService<ISaveLoadService>(new SaveLoadService(_services.Service<IProgressService>()));

        private void OnLoaded() => 
            _gameStateMachine.Enter<LoadProgressState>();
    }
}
