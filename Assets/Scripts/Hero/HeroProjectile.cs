using Assets.Scripts.Enemy;
using Assets.Scripts.GameLogic.Pool;
using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class HeroProjectile : ProjectileBase
    {       
        private void OnTriggerEnter2D(Collider2D collision)
        {
            IHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(_damage);
                _projectilePool.ReturnProjectileToPool(this);
            }
        }
    }
}
