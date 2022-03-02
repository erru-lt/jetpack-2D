using Assets.Scripts.GameLogic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private FX _deathFx;

        private void Start() => 
            _enemyHealth.HealthChanged += OnHealthChanged;

        private void OnHealthChanged()
        {
            if (_enemyHealth.CurrentHealth <= 0)
            {
                Die();
                SpawnFx();
            }
        }

        private void Die() => 
            Destroy(gameObject);

        private void SpawnFx() => 
            _deathFx.SpawnFx(transform.position);
    }
}
