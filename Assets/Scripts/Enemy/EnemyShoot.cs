using Assets.Scripts.GameLogic;
using Assets.Scripts.GameLogic.Pool;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyShoot : MonoBehaviour
    {
        public float Damage { get; set; }

        [SerializeField] private float _shootCooldownMax;
        private float _shootCooldown;
        private bool _isShooting;

        [SerializeField] private Transform _gun;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        private EnemyProjectilePool _enemyProjectilePool;
        private Sprite _projectileSprite;

        public void Construct(EnemyProjectilePool enemyProjectilePool, Sprite projectileSprite)
        {
            _enemyProjectilePool = enemyProjectilePool;
            _projectileSprite = projectileSprite;
        }

        private void Update()
        {
            UpdateCooldown();
            StartShoot();
        }

        public void EnableShoot()
        {
            _isShooting = true;
            _enemyAnimator.PlayIdle();
        }

        public void DisableShoot()
        {
            _isShooting = false;
            _enemyAnimator.PlayRun();
        }

        private bool CanShoot() =>
            _isShooting && CooldownIsUp();

        private void StartShoot()
        {
            if(CanShoot())
            {
                CreateProjectile();
                ResetCooldown();
            }
        }

        private void CreateProjectile()
        {
            ProjectileBase projectile = _enemyProjectilePool.TakeProjectileFromPool();
            projectile.transform.position = _gun.position;
            projectile.Construct(_enemyProjectilePool, Damage);
            projectile.AddForce(-transform.right);
            projectile.AddSprite(_projectileSprite);
        }

        private void UpdateCooldown()
        {
            if(CooldownIsUp() == false)
            {
                _shootCooldown -= Time.deltaTime;
            }
        }

        private bool CooldownIsUp() =>
            _shootCooldown <= 0;

        private void ResetCooldown() => 
            _shootCooldown = _shootCooldownMax;
    }
}
