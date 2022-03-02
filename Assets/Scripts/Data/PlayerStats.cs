using System;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class PlayerStats
    {
        public event Action HpRestored;

        public Sprite ProjectileSprite;
        public float Damage;

        public float CurrentHealth;
        public float MaxHealth;

        public float MoveSpeed;
        public float RegularMoveSpeed;
        public float IncreasedMoveSpeed;

        public void UpdateAttackStats(Sprite projectileSprite, float damage)
        {
            ProjectileSprite = projectileSprite;
            Damage = damage;
        }

        public void ResetHp()
        {
            CurrentHealth = MaxHealth;
            HpRestored?.Invoke();
        }

        public void IncreaseMoveSpeed() => 
            MoveSpeed = IncreasedMoveSpeed;

        public void DecreaseMoveSpeed() => 
            MoveSpeed = RegularMoveSpeed;

        public bool AttackStatsIsEmpty() =>
           Damage == 0 && ProjectileSprite == null;
    }
}
