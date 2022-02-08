using UnityEngine;

namespace Assets.Scripts.Hero
{
    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    { 
        [SerializeField] private HeroHealth _heroHealth;

        private void Start()
        {
            _heroHealth.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if(_heroHealth.CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
