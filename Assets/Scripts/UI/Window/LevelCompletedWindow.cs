using Assets.Scripts.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Window
{
    public class LevelCompletedWindow : MonoBehaviour
    {
        private const string SelectLevelScene = "SelectLevel";

        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        private IGameStateMachine _gameStateMachine;

        public void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Awake()
        {
            NextLevelButton();
            MainMenuButton();
        }

        private void NextLevelButton() => 
            _nextLevelButton.onClick.AddListener(() => StartNextLevel());

        private void MainMenuButton() => 
            _mainMenuButton.onClick.AddListener(() => LoadMainMenuScene());

        private void StartNextLevel() =>
            _gameStateMachine.Enter<SelectLevelState, string>(SelectLevelScene);

        private void LoadMainMenuScene() => 
            _gameStateMachine.Enter<LoadProgressState>();
    }
}
