using UnityEngine;

namespace Assets.Scripts.StaticData.Enemy
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Static Data/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyTypeID enemyTypeID;

        [Range(1.5f, 5.5f)]
        public float Damage;

        [Range(1.5f, 5.5f)]
        public float Health;

        [Range(1.0f, 2.5f)]
        public float MoveSpeed;

        public Sprite ProjectileSprite;
        public GameObject Prefab;
    }
}
