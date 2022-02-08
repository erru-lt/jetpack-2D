using Assets.Scripts.Infrastructure;
using Assets.Scripts.Infrastructure.States;

public class Game
{
    public GameStateMachine GameStateMachine;

    public Game(ICoroutineRunner coroutineRunner) =>
        GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
}
