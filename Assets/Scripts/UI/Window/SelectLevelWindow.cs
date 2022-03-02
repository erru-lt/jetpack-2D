using Assets.Scripts.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Window
{
    public class SelectLevelWindow : MonoBehaviour
    {
        private const string MainMenuScene = "MainMenu";
        private const string InventoryScene = "Inventory";

        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _inventoryButton;

        private IGameStateMachine _gameStateMachine;

        public void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Awake()
        {
            InventoryButton();
            CloseButton();
        }

        private void InventoryButton() => 
            _inventoryButton.onClick.AddListener(() => _gameStateMachine.Enter<InventoryState, string>(InventoryScene));

        private void CloseButton() => 
            _closeButton.onClick.AddListener(() => _gameStateMachine.Enter<MainMenuState, string>(MainMenuScene));
    }
}
