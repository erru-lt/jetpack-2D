using Assets.Scripts.Infrastructure;
using Assets.Scripts.Infrastructure.States;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{

    private Game _game;

    private void Awake()
    {
        _game = new Game(this);
        _game.GameStateMachine.Enter<BootstrapState>();

        DontDestroyOnLoad(this);
    }
}