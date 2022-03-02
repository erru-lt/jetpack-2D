using Assets.Scripts.GameLogic;
using Assets.Scripts.Hero;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyCollision : MonoBehaviour
    {
        public float Damage { get; set; }

        [SerializeField] private FX _explodeFx;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IHealth health = collision.gameObject.GetComponent<HeroHealth>();

            if(health != null)
            {
                health.TakeDamage(Damage);
                Die();
                SpawnFx();
            }
        }

        private void Die() => 
            Destroy(gameObject);

        private void SpawnFx() => 
            _explodeFx.SpawnFx(transform.position);
    }
}
