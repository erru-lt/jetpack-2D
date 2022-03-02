using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.StaticData.Enemy;
using UnityEngine;

namespace Assets.Scripts.GameLogic.Spawner
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        public EnemyTypeID EnemyTypeID;
        public Vector3 Position;

        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        private void Start() => 
            SpawnEnemy();

        private void SpawnEnemy() =>
            _gameFactory.CreateEnemy(EnemyTypeID, Position);

    }
}
