using Assets.Scripts.GameLogic.Camera;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.States.Interfaces;
using Assets.Scripts.StaticData;
using Assets.Scripts.StaticData.Level;
using Assets.Scripts.UI.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private readonly IStaticDataService _staticDataService;

        public LoadLevelState(SceneLoader sceneLoader, IGameFactory gameFactory, IUIFactory uiFactory, IStaticDataService staticDataService)
        {
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _staticDataService = staticDataService;
        }

        public void Enter(string levelName) => 
            _sceneLoader.Load(levelName, OnLoaded);

        private void OnLoaded()
        {
            InitializeUIRoot();
            InitializeGameWorld();
        }

        private void InitializeGameWorld()
        {
            LevelStaticData levelStaticData = _staticDataService.LevelData(SceneManager.GetActiveScene().name);

            InitializeHeroProjectilePool();
            InitializeEnemyProjectilePool();
            GameObject hero = InitializeHero(levelStaticData);
            InitializeHud();
            InitializeSpawners(levelStaticData);
            InitializeLevelTransitionTrigger(levelStaticData);
            CameraFollowTarget(hero.transform);
        }

        private void InitializeUIRoot() =>
            _uiFactory.CreateUIRoot();

        private void InitializeEnemyProjectilePool() => 
            _gameFactory.CreateEnemyProjectilePool();

        private void InitializeHeroProjectilePool() => 
            _gameFactory.CreateHeroProjectilePool();

        private GameObject InitializeHero(LevelStaticData levelStaticData) => 
            _gameFactory.CreateHero(levelStaticData.HeroInitialPoint);

        private void InitializeHud() =>
            _gameFactory.CreateHud();

        private void InitializeSpawners(LevelStaticData levelStaticData)
        {
            foreach (EnemySpawnerStaticData enemySpawnerStaticData in levelStaticData.Spawners)
            {
                _gameFactory.CreateSpawner(enemySpawnerStaticData.EnemyTypeID, enemySpawnerStaticData.Position);
            }
        }

        private void InitializeLevelTransitionTrigger(LevelStaticData levelStaticData) => 
            _gameFactory.CreateLevelTransitionTrigger(levelStaticData.LevelTransiotionPoint);

        private void CameraFollowTarget(Transform target) => 
            Camera.main.GetComponent<CameraFollow>().SetTarget(target);

        public void Exit()
        {

        }
    }
}
