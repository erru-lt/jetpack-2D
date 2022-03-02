using Assets.Scripts.Data;
using Assets.Scripts.Hero;
using UnityEngine;

namespace Assets.Scripts.UI.Elements
{
    public class HPBarPerformer : MonoBehaviour
    {
        [SerializeField] private HPBar _hpBar;
        private HeroHealth _heroHealth;
        private PlayerStats _playerStats;

        public void Construct(HeroHealth heroHealth, PlayerStats playerStats)
        {
            _heroHealth = heroHealth;
            _playerStats = playerStats;

            _heroHealth.HealthChanged += UpdateHpBar;
            _playerStats.HpRestored += UpdateHpBar;
        }

        private void OnDestroy()
        {
            if (_heroHealth != null)
            {
                _heroHealth.HealthChanged -= UpdateHpBar;
                _playerStats.HpRestored -= UpdateHpBar;
            }
        }

        private void UpdateHpBar() => 
            _hpBar.SetValue(_heroHealth.CurrentHealth, _heroHealth.MaxHealth);
    }
}
