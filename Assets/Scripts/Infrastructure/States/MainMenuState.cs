using Assets.Scripts.Infrastructure.States.Interfaces;

namespace Assets.Scripts.Infrastructure.States
{
    public class MainMenuState : IState
    {
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;

        public MainMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load("Level1");
        }

        public void Exit()
        {
            
        }
    }
}
