using Assets.Scripts.GameLogic.Pool;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.StaticData.Enemy;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        EnemyProjectilePool CreateEnemyProjectilePool();
        HeroProjectilePool CreateHeroProjectilePool();
        GameObject CreateHero(Vector3 position);
        GameObject CreateHud();
        void CreateEnemy(EnemyTypeID enemyTypeID, Vector3 position);
        GameObject CreateSpawner(EnemyTypeID enemyTypeID, Vector3 position);
        GameObject CreateLevelTransitionTrigger(Vector3 position);
    }
}