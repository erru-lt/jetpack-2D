using Assets.Scripts.Infrastructure.States.Interfaces;

namespace Assets.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {

        private SceneLoader _sceneLoader;

        public LoadLevelState(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter(string levelName)
        {

            _sceneLoader.Load(levelName, OnLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            
        }
    }
}
