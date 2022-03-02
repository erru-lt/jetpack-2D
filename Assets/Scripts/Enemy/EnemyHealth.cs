using Assets.Scripts.GameLogic;
using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public event Action HealthChanged;

        private float _maxHealth;
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

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            
            HealthChanged?.Invoke();
        }
    }
}
