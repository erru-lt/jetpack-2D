using Assets.Scripts.Infrastructure.States.Interfaces;

namespace Assets.Scripts.Infrastructure.States
{
    public class BootstrapState : IState
    {

        private const string Level1 = "Level1";

        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(Level1);
        }

        public void Exit()
        {

        }
    }
}
