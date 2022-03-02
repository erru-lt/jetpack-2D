using Assets.Scripts.Infrastructure.States;

namespace Assets.Scripts.Infrastructure
{
    public class Game
    {
        public GameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner) =>
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
    }
}