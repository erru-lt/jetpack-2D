using Assets.Scripts.GameLogic;
using Assets.Scripts.GameLogic.Pool;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyShoot : MonoBehaviour
    {
        [SerializeField] private float _shootCooldownMax;
        private float _shootCooldown;
        private bool _isShooting;
        private float _damage = 2.0f;

        [SerializeField] private Transform _gun;
        [SerializeField] private EnemyAnimator _enemyAnimator;
        [SerializeField] private EnemyProjectilePool _enemyProjectilePool;
        [SerializeField] private Sprite _projectileSprite;


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
            projectile.Construct(_enemyProjectilePool, _damage);
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
