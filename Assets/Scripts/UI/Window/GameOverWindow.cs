using Assets.Scripts.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Window
{
    public class GameOverWindow : MonoBehaviour
    {
        private const string SelectLevelScene = "SelectLevel";

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        private IGameStateMachine _gameStateMachine;

        public void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Awake()
        {
            RestartButton();
            MainMenuButton();
        }

        private void RestartButton() => 
            _restartButton.onClick.AddListener(() => RestartCurrentLevel());

        private void MainMenuButton() => 
            _mainMenuButton.onClick.AddListener(() => LoadMainMenuScene());

        private void RestartCurrentLevel() =>
            _gameStateMachine.Enter<SelectLevelState, string>(SelectLevelScene);

        private void LoadMainMenuScene() => 
            _gameStateMachine.Enter<LoadProgressState>();
    } 
}
