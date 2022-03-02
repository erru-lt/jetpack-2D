using Assets.Enemy;
using Assets.Scripts.Enemy;
using Assets.Scripts.GameLogic;
using Assets.Scripts.GameLogic.Pool;
using Assets.Scripts.GameLogic.Spawner;
using Assets.Scripts.Hero;
using Assets.Scripts.Infrastructure.AssetManagement;
using Assets.Scripts.Infrastructure.Services.InputService;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.SaveLoadService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.StaticData.Enemy;
using Assets.Scripts.UI.Elements;
using Assets.Scripts.UI.Factory;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider _assetProvider;
        private IInputService _inputService;
        private IStaticDataService _staticDataService;
        private IGameStateMachine _gameStateMachine;
        private IProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        private IUIFactory _uiFactory;

        private GameObject _hero;
        private HeroProjectilePool _heroProjectilePool;
        private EnemyProjectilePool _enemyProjectilePool;

        public GameFactory(IAssetProvider assetProvider, IInputService inputService, IStaticDataService staticDataService, IGameStateMachine gameStateMachine, IProgressService progressService, ISaveLoadService saveLoadService, IUIFactory uiFactory)
        {
            _assetProvider = assetProvider;
            _inputService = inputService;
            _staticDataService = staticDataService;
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _uiFactory = uiFactory;
        }

        public GameObject CreateHero(Vector3 position)
        {
            _hero = _assetProvider.Instantiate(AssetPath.HeroPath, position);

            _hero.GetComponent<HeroMove>().Construct(_progressService.PlayerProgress.PlayerStats);
            _hero.GetComponent<HeroAttack>().Construct(_inputService, _heroProjectilePool, _progressService);
            _hero.GetComponent<HeroDeath>().Construct(_uiFactory);
            _hero.GetComponent<HeroFly>().Construct(_inputService);
            _hero.GetComponent<HeroPickup>().Construct(_progressService);
            _hero.GetComponent<HeroHealth>().Construct(_progressService.PlayerProgress.PlayerStats);
            _hero.GetComponent<HeroPowerup>().Construct(_progressService.PlayerProgress.PlayerStats);

            return _hero;
        }

        public GameObject CreateHud()
        {
            GameObject hud = _assetProvider.Instantiate(AssetPath.HudPath);
            hud.GetComponentInChildren<HPBarPerformer>().Construct(_hero.GetComponent<HeroHealth>(), _progressService.PlayerProgress.PlayerStats);

            return hud;
        }

        public void CreateEnemy(EnemyTypeID enemyTypeID, Vector3 spawnPosition)
        {
            switch (enemyTypeID)
            {
                case EnemyTypeID.Bomberman:
                    CreateBomberman(enemyTypeID, spawnPosition);
                    break;

                case EnemyTypeID.Drone:
                    CreateDrone(enemyTypeID, spawnPosition);
                    break;

                case EnemyTypeID.WalkingShooter:
                    CreateWalkingShooter(enemyTypeID, spawnPosition);
                    break;
            }
        }

        public GameObject CreateSpawner(EnemyTypeID enemyTypeID, Vector3 position)
        {
            GameObject spawner = _assetProvider.Instantiate(AssetPath.EnemySpawnPointPath, position);
            EnemySpawnPoint enemySpawnPoint = spawner.GetComponent<EnemySpawnPoint>();

            enemySpawnPoint.Construct(this);
            enemySpawnPoint.EnemyTypeID = enemyTypeID;
            enemySpawnPoint.Position = position;

            return spawner;
        }

        public GameObject CreateLevelTransitionTrigger(Vector3 position)
        {
            GameObject levelTransitionTrigger = _assetProvider.Instantiate(AssetPath.LevelTransitionTriggerPath, position);
            levelTransitionTrigger.GetComponent<LevelTransitionTrigger>().Construct(_gameStateMachine, _progressService, _saveLoadService, _staticDataService);

            return levelTransitionTrigger;
        }

        public HeroProjectilePool CreateHeroProjectilePool() =>
            _heroProjectilePool = _assetProvider.Instantiate(AssetPath.HeroProjectilePoolPath).GetComponent<HeroProjectilePool>();

        public EnemyProjectilePool CreateEnemyProjectilePool() =>
            _enemyProjectilePool = _assetProvider.Instantiate(AssetPath.EnemyProjectilePoolPath).GetComponent<EnemyProjectilePool>();

        private GameObject CreateBomberman(EnemyTypeID enemyTypeID, Vector3 spawnPosition)
        {
            EnemyStaticData enemyStaticData = GetEnemyStaticData(enemyTypeID);
            GameObject bomberman = InstantiateEnemy(enemyStaticData);

            SpawnPosition(bomberman, spawnPosition);
            ConstructEnemyPatrol(enemyStaticData, bomberman);

            EnemyChase enemyChase = bomberman.GetComponent<EnemyChase>();
            enemyChase.Construct(_hero.transform);
            enemyChase.MoveSpeed = enemyStaticData.MoveSpeed;

            EnemyExplode enemyExplode = bomberman.GetComponent<EnemyExplode>();
            enemyExplode.Construct(_hero.transform);
            enemyExplode.Damage = enemyStaticData.Damage;

            ConstructHealth(enemyStaticData, bomberman);

            return bomberman;
        }

        private GameObject CreateDrone(EnemyTypeID enemyTypeID, Vector3 spawnPosition)
        {
            EnemyStaticData enemyStaticData = GetEnemyStaticData(enemyTypeID);
            GameObject drone = InstantiateEnemy(enemyStaticData);

            SpawnPosition(drone, spawnPosition);

            EnemyMove enemyMove = drone.GetComponent<EnemyMove>();
            enemyMove.MoveSpeed = enemyStaticData.MoveSpeed;

            EnemyCollision enemyCollision = drone.GetComponent<EnemyCollision>();
            enemyCollision.Damage = enemyStaticData.Damage;

            ConstructHealth(enemyStaticData, drone);

            return drone;
        }

        private GameObject CreateWalkingShooter(EnemyTypeID enemyTypeID, Vector3 spawnPosition)
        {
            EnemyStaticData enemyStaticData = GetEnemyStaticData(enemyTypeID);
            GameObject walkingShooter = InstantiateEnemy(enemyStaticData);

            SpawnPosition(walkingShooter, spawnPosition);
            ConstructEnemyPatrol(enemyStaticData, walkingShooter);

            EnemyShoot enemyShoot = walkingShooter.GetComponent<EnemyShoot>();
            enemyShoot.Construct(_enemyProjectilePool, enemyStaticData.ProjectileSprite);
            enemyShoot.Damage = enemyStaticData.Damage;

            ConstructHealth(enemyStaticData, walkingShooter);

            return walkingShooter;
        }

        private void SpawnPosition(GameObject enemy, Vector3 spawnPosition) =>
            enemy.transform.position = spawnPosition;

        private void ConstructHealth(EnemyStaticData enemyStaticData, GameObject enemy)
        {
            IHealth health = enemy.GetComponent<IHealth>();
            health.CurrentHealth = enemyStaticData.Health;
            health.MaxHealth = enemyStaticData.Health;
        }

        private void ConstructEnemyPatrol(EnemyStaticData enemyStaticData, GameObject enemy)
        {
            EnemyPatrol enemyPatrol = enemy.GetComponent<EnemyPatrol>();
            enemyPatrol.Speed = enemyStaticData.MoveSpeed;
        }

        private GameObject InstantiateEnemy(EnemyStaticData enemyStaticData) =>
            Object.Instantiate(enemyStaticData.Prefab);

        private EnemyStaticData GetEnemyStaticData(EnemyTypeID enemyTypeID) =>
            _staticDataService.EnemyData(enemyTypeID);
    }
}
