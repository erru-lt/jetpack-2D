using Assets.Scripts.StaticData.Enemy;
using System;
using UnityEngine;

namespace Assets.Scripts.StaticData
{
    [Serializable]
    public class EnemySpawnerStaticData
    {
        public EnemyTypeID EnemyTypeID;
        public Vector3 Position;

        public EnemySpawnerStaticData(EnemyTypeID enemyTypeID, Vector3 position)
        {
            EnemyTypeID = enemyTypeID;
            Position = position;
        }
    }
}
