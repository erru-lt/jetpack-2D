using Assets.Scripts.Infrastructure.AssetManagement;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.SaveLoadService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.UI.Elements;
using Assets.Scripts.UI.Window;
using UnityEngine;

namespace Assets.Scripts.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private IGameStateMachine _gameStateMachine;
        private IAssetProvider _assetProvider;
        private IProgressService _progressService;
        private IStaticDataService _staticDataService;
        private ISaveLoadService _saveLoadService;

        private Transform _uiRoot;

        public UIFactory(IGameStateMachine gameStateMachine, IAssetProvider assetProvider, IProgressService progressService, IStaticDataService staticDataService, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _assetProvider = assetProvider;
            _progressService = progressService;
            _staticDataService = staticDataService;
            _saveLoadService = saveLoadService;
        }

        public GameObject CreateMainMenuWindow()
        {
            GameObject mainMenuWindow = _assetProvider.Instantiate(AssetPath.MainMenuWindowPath, _uiRoot);
            mainMenuWindow.GetComponent<MainMenuWindow>().Construct(_gameStateMachine);

            return mainMenuWindow;
        }

        public GameObject CreateSelectLevelWindow()
        {
            GameObject selectLevelWindow = _assetProvider.Instantiate(AssetPath.SelectLevelWindowPath, _uiRoot);
            selectLevelWindow.GetComponent<SelectLevelWindow>().Construct(_gameStateMachine);

            selectLevelWindow.GetComponentInChildren<LevelContainer>().Construct(_gameStateMachine, this, _progressService, _staticDataService);
            selectLevelWindow.GetComponentInChildren<CoinCounter>().Construct(_progressService.PlayerProgress);

            return selectLevelWindow;
        }

        public GameObject CreateGameOverWindow()
        {
            GameObject gameOverWindow = _assetProvider.Instantiate(AssetPath.GameOverWindowPath, _uiRoot);
            gameOverWindow.GetComponent<GameOverWindow>().Construct(_gameStateMachine);

            return gameOverWindow;
        }

        public GameObject CreateLevelCompletedWindow()
        {
            GameObject levelCompletedWindow = _assetProvider.Instantiate(AssetPath.LevelCompletedWindowPath, _uiRoot);
            levelCompletedWindow.GetComponent<LevelCompletedWindow>().Construct(_gameStateMachine);

            return levelCompletedWindow;
        }

        public GameObject CreateInventoryWindow()
        {
            GameObject inventoryWindow = _assetProvider.Instantiate(AssetPath.InventoryWindowPath, _uiRoot);
            inventoryWindow.GetComponent<InventoryWindow>().Construct(_gameStateMachine, _saveLoadService);

            inventoryWindow.GetComponentInChildren<InventoryItemContainer>().Construct(this, _progressService);
            inventoryWindow.GetComponentInChildren<CoinCounter>().Construct(_progressService.PlayerProgress);

            return inventoryWindow;
        }

        public GameObject CreateInventoryItem(Transform parent) =>
            _assetProvider.Instantiate(AssetPath.InventoryItemPath, parent);

        public GameObject CreateLevelStartButton(Vector3 position, Transform parent) =>
            _assetProvider.Instantiate(AssetPath.LevelStartButtonPath, position, parent);

        public void CreateUIRoot() => 
            _uiRoot = _assetProvider.Instantiate(AssetPath.UIRootPath).transform;
    }
}
