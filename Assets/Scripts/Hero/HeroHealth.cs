using Assets.Scripts.GameLogic;
using System;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class HeroHealth : MonoBehaviour, IHealth
    {
        public event Action HealthChanged;

        [SerializeField] private float _maxHealth;
        private float _currentHealth;
        
        public float CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }
        public float MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;

            HealthChanged?.Invoke();
        }
    }
}
