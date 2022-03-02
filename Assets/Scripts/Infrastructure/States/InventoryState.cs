using Assets.Scripts.Infrastructure.States.Interfaces;
using Assets.Scripts.UI.Factory;

namespace Assets.Scripts.Infrastructure.States
{
    public class InventoryState : IPayloadState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;

        public InventoryState(SceneLoader sceneLoader, IUIFactory uiFactory)
        {           
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        private void OnLoaded()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateInventoryWindow();
        }

        public void Exit()
        {

        }
    }
}