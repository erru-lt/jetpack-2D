using Assets.Scripts.GameLogic;
using Assets.Scripts.Hero;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyProjectile : ProjectileBase
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            IHealth heroHealth = collision.gameObject.GetComponent<HeroHealth>();

            if(heroHealth != null)
            {
                heroHealth.TakeDamage(_damage);
                _projectilePool.ReturnProjectileToPool(this);
            }
        }
    }
}
