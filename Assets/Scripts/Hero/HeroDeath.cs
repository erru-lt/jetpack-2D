using Assets.Scripts.UI.Factory;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    { 
        [SerializeField] private HeroHealth _heroHealth;
        [SerializeField] private HeroAnimator _heroAnimator;

        private IUIFactory _uiFactory;

        public void Construct(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        private void Start() => 
            _heroHealth.HealthChanged += OnHealthChanged;

        private void OnHealthChanged()
        {
            if(_heroHealth.CurrentHealth <= 0)
            {
                DieAnimation();
            }
        }

        private void OnDieAnimationEnd()
        {
            Die();
            _uiFactory.CreateGameOverWindow();
        }

        private void Die() => 
            Destroy(gameObject);

        private void DieAnimation() => 
            _heroAnimator.PlayDie();
    }
}
