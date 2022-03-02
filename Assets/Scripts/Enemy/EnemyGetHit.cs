using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(EnemyHealth))]
    public class EnemyGetHit : MonoBehaviour
    {
        private readonly float _delay = 0.3f;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private EnemyHealth _enemyHealth;

        [SerializeField] private Color _hitColor;
        private Color _defaultColor;

        private void Start()
        {
            _defaultColor = _spriteRenderer.color;
            _enemyHealth.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            Knockback();
            ChangeSprite();
        }

        private void Knockback() => 
            _rigidbody.AddForce(transform.right * 200, ForceMode2D.Impulse);

        private void ChangeSprite() => 
            StartCoroutine(ChangeSpriteCo());

        private IEnumerator ChangeSpriteCo()
        {
            _spriteRenderer.color = _hitColor;
            yield return new WaitForSeconds(_delay);
            _spriteRenderer.color = _defaultColor;
        }

        private void OnDestroy() => 
            _enemyHealth.HealthChanged -= OnHealthChanged;
    }
}
