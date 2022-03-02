using Assets.Scripts.StaticData.Enemy;
using Assets.Scripts.StaticData.Level;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string EnemyStaticDataPath = "StaticData/Enemy";
        private const string LevelStaticDataPath = "StaticData/Level";

        private Dictionary<EnemyTypeID, EnemyStaticData> _enemies;
        private Dictionary<string, LevelStaticData> _levels;

        public void Load()
        {
            LoadEnemyStaticData();
            LoadLevelStaticData();
        }

        public EnemyStaticData EnemyData(EnemyTypeID enemyTypeID) =>
            _enemies.TryGetValue(enemyTypeID, out EnemyStaticData enemyStaticData)
                ? enemyStaticData
                : null;

        public LevelStaticData LevelData(string levelName) =>
            _levels.TryGetValue(levelName, out LevelStaticData levelStaticData)
                ? levelStaticData
                : null;

        private void LoadEnemyStaticData()
        {
            _enemies = Resources
                .LoadAll<EnemyStaticData>(EnemyStaticDataPath)
                .ToDictionary(x => x.enemyTypeID, x => x);
        }

        private void LoadLevelStaticData()
        {
            _levels = Resources
                .LoadAll<LevelStaticData>(LevelStaticDataPath)
                .ToDictionary(x => x.LevelName, x => x);
        }
    }
}
