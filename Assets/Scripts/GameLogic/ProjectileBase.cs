using Assets.Scripts.GameLogic.Pool;
using UnityEngine;

namespace Assets.Scripts.GameLogic
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class ProjectileBase : MonoBehaviour
    {
        protected float _damage;
        [SerializeField] private float _bulletForce;

        [SerializeField] private float _lifetimeDurationMax;
        private float _lifetimeDuration;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        protected ProjectilePoolBase _projectilePool;

        public void Construct(ProjectilePoolBase projectilePool, float damage)
        {
            _projectilePool = projectilePool;
            _damage = damage;
        }

        private void Update() =>
            CheckLifetime();

        private void OnEnable() =>
            ResetLifetimeTimer();

        private void OnDisable()
        {
            ResetForce();
            RemoveSprite();
        }

        public void AddForce(Vector3 direction) =>
            _rigidbody.AddForce(direction * _bulletForce, ForceMode2D.Impulse);

        public void AddSprite(Sprite projectileSprite) =>
            _spriteRenderer.sprite = projectileSprite;

        private void CheckLifetime()
        {
            _lifetimeDuration -= Time.deltaTime;
            if (_lifetimeDuration <= 0)
            {
                _projectilePool.ReturnProjectileToPool(this);
            }
        }

        private void ResetLifetimeTimer() =>
            _lifetimeDuration = _lifetimeDurationMax;

        private void ResetForce() =>
            _rigidbody.velocity = Vector3.zero;

        private void RemoveSprite() =>
            _spriteRenderer.sprite = null;
    }
}