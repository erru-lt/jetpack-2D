using Assets.Scripts.Data;
using Assets.Scripts.GameLogic;
using System;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class HeroHealth : MonoBehaviour, IHealth
    {
        public event Action HealthChanged;

        public float CurrentHealth
        {
            get => _playerStats.CurrentHealth;
            set => _playerStats.CurrentHealth = value;
        }
        public float MaxHealth
        {
            get => _playerStats.MaxHealth;
            set => _playerStats.MaxHealth = value;
        }

        private PlayerStats _playerStats;

        public void Construct(PlayerStats playerStats) => 
            _playerStats = playerStats;

        private void Start()
        {
            _playerStats.ResetHp();
            Debug.Log(CurrentHealth);
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;

            HealthChanged?.Invoke();
        }
    }
}
