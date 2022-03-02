using Assets.Scripts.Data;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.SaveLoadService;
using Assets.Scripts.Infrastructure.States.Interfaces;

namespace Assets.Scripts.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private const string SceneToLoad = "MainMenu";

        private readonly GameStateMachine _gameStateMachine;
        private readonly IProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IProgressService progressService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<MainMenuState, string>(SceneToLoad);
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.PlayerProgress = _saveLoadService.Load() ?? InitNewProgress();
            _progressService.PlayerProgress.PlayerLoot.ResetCurrentLevelCoins();
        }

        private PlayerProgress InitNewProgress()
        {
            PlayerProgress playerProgress = new PlayerProgress();
            InitializeNewStats(playerProgress);

            return playerProgress;
        }

        private void InitializeNewStats(PlayerProgress playerProgress)
        {
            playerProgress.LevelProgress.LevelAt = InitialStats._startLevelIndex;
            playerProgress.PlayerStats.MaxHealth = InitialStats._maxHeroHealth;
            playerProgress.PlayerStats.IncreasedMoveSpeed = InitialStats._increasedMoveSpeed;
            playerProgress.PlayerStats.RegularMoveSpeed = InitialStats._heroMoveSpeed;
            playerProgress.PlayerStats.MoveSpeed = playerProgress.PlayerStats.RegularMoveSpeed;
        }

        public void Exit()
        {

        }
    }
}
