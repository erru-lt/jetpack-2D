using System;

namespace Assets.Scripts.GameLogic
{
    public interface IHealth
    {
        event Action HealthChanged;

        float CurrentHealth { get; set; }

        float MaxHealth { get; set; }

        void TakeDamage(float damage);
    }
}
