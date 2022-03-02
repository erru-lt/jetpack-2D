using Assets.Scripts.Infrastructure.Services.SaveLoadService;
using Assets.Scripts.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Window
{
    public class InventoryWindow : MonoBehaviour
    {
        private const string SelectLevelScene = "SelectLevel";

        [SerializeField] private Button _closeButton;
        private IGameStateMachine _gameStateMachine;
        private ISaveLoadService _saveLoadService;

        public void Construct(IGameStateMachine gameStateMachine, ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _gameStateMachine = gameStateMachine;
        }

        private void Awake() => 
            CloseButton();

        private void CloseButton() => 
            _closeButton.onClick.AddListener(() => OnWindowClose());

        private void OnWindowClose()
        {
            _gameStateMachine.Enter<SelectLevelState, string>(SelectLevelScene);
            _saveLoadService.Save();
        }
    }
}
