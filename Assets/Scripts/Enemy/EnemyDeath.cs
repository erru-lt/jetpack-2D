using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private GameObject _dieFx;
        private void Start()
        {
            _enemyHealth.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (_enemyHealth.CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Instantiate(_dieFx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
