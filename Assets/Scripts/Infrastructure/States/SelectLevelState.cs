using Assets.Scripts.Infrastructure.States.Interfaces;
using Assets.Scripts.UI.Factory;

namespace Assets.Scripts.Infrastructure.States
{
    public class SelectLevelState : IPayloadState<string>
    {
        private SceneLoader _sceneLoader;
        private IUIFactory _uiFactory;

        public SelectLevelState(SceneLoader sceneLoader, IUIFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        private void OnLoaded()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.CreateSelectLevelWindow();
        }

        public void Exit()
        {
            
        }    
    }
}
