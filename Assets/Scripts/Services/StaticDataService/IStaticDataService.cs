using Assets.Scripts.StaticData.Enemy;
using Assets.Scripts.StaticData.Level;

namespace Assets.Scripts.Infrastructure.Services.StaticDataService
{
    public interface IStaticDataService : IService
    {
        EnemyStaticData EnemyData(EnemyTypeID enemyTypeID);
        LevelStaticData LevelData(string levelName);
        void Load();
    }
}