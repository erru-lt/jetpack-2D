using Assets.Scripts.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Window
{
    public class MainMenuWindow : MonoBehaviour
    {
        private const string SelectLevelScene = "SelectLevel";

        private IGameStateMachine _gameStateMachine;
        [SerializeField] private Button _playButton;

        public void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Awake() => 
            PlayButton();

        private void PlayButton() => 
            _playButton.onClick.AddListener(() => _gameStateMachine.Enter<SelectLevelState, string>(SelectLevelScene));
    }
}
