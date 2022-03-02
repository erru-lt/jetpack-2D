using Assets.Scripts.Hero;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.Infrastructure.Services.SaveLoadService;
using Assets.Scripts.Infrastructure.Services.StaticDataService;
using Assets.Scripts.Infrastructure.States;
using Assets.Scripts.StaticData.Level;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameLogic
{
    public class LevelTransitionTrigger : MonoBehaviour
    {
        private bool _isTriggered;

        private IGameStateMachine _gameStateMachine;
        private IProgressService _progressService;
        private ISaveLoadService _saveLoadService;
        private IStaticDataService _staticDataService;

        public void Construct(IGameStateMachine gameStateMachine, IProgressService progressService, ISaveLoadService saveLoadService, IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _staticDataService = staticDataService;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isTriggered) return;

            HeroMove hero = collision.gameObject.GetComponent<HeroMove>();

            if (hero != null)
            {
                _isTriggered = true;
                UnlockLevel();
                CoinsData();
                SaveData();
                _gameStateMachine.Enter<EndLevelState>();
            }
        }

        private void CoinsData()
        {
            LevelStaticData levelStaticData = _staticDataService.LevelData(SceneManager.GetActiveScene().name);

            if (levelStaticData.CoinsPicked < _progressService.PlayerProgress.PlayerLoot.CurrentLevelCoins)
            {
                levelStaticData.CoinsPicked = _progressService.PlayerProgress.PlayerLoot.CurrentLevelCoins;
            }

            _progressService.PlayerProgress.PlayerLoot.ResetCurrentLevelCoins();
        }

        private void UnlockLevel() => 
            _progressService.PlayerProgress.LevelProgress.UnlockNextLevel(SceneManager.GetActiveScene().buildIndex);

        private void SaveData() =>
           _saveLoadService.Save();
    }
}
