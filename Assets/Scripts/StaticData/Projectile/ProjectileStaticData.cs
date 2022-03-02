using UnityEngine;

namespace Assets.Scripts.StaticData.Projectile
{
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "Static Data/Projectile")]
    public class ProjectileStaticData : ScriptableObject
    {
        public Sprite UIProjectileImage;
        public Sprite ProjectileSprite;
        public float Damage;
        public float Speed;
        public bool IsPurchased;
    }
}
