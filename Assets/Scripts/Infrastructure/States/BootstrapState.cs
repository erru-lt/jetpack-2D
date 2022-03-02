using Assets.Scripts.Infrastructure.AssetManagement;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.Services.InputService;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.SaveLoadService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.States.Interfaces;
using Assets.Scripts.UI.Factory;

namespace Assets.Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _services = services;

            RegisterServices();
        }

        public void Enter() => 
            OnLoaded();

        private void RegisterServices()
        {
            RegisterGameStateMachine();
            RegisterInputService();
            RegisterAssetProviderService();
            RegisterProgressService();
            RegisterSaveLoadService();
            RegisterStaticDataService();
            RegisterUIFactory();
            RegisterGameFactory();
        }

        private void RegisterGameStateMachine() => 
            _services.RegisterService<IGameStateMachine>(_gameStateMachine);

        private void RegisterInputService() => 
            _services.RegisterService<IInputService>(new InputService());

        private void RegisterAssetProviderService() => 
            _services.RegisterService<IAssetProvider>(new AssetProvider());

        private void RegisterProgressService() => 
            _services.RegisterService<IProgressService>(new ProgressService());

        private void RegisterSaveLoadService() => 
            _services.RegisterService<ISaveLoadService>(new SaveLoadService(_services.Service<IProgressService>()));

        private void RegisterStaticDataService()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.Load();
            _services.RegisterService<IStaticDataService>(staticDataService);
        }

        private void RegisterGameFactory() => 
            _services.RegisterService<IGameFactory>(new GameFactory(
                _services.Service<IAssetProvider>(),
                _services.Service<IInputService>(),
                _services.Service<IStaticDataService>(),
                _services.Service<IGameStateMachine>(),
                _services.Service<IProgressService>(),
                _services.Service<ISaveLoadService>(),
                _services.Service<IUIFactory>()
                ));

        private void RegisterUIFactory() => 
            _services.RegisterService<IUIFactory>(new UIFactory(
                _gameStateMachine, _services.Service<IAssetProvider>(),
                _services.Service<IProgressService>(),
                _services.Service<IStaticDataService>(),
                _services.Service<ISaveLoadService>()
                ));

        private void OnLoaded() => 
            _gameStateMachine.Enter<LoadProgressState>();

        public void Exit()
        {

        }
    }
}
