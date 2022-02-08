using Assets.Scripts.GameLogic;
using Assets.Scripts.GameLogic.Pool;
using Assets.Scripts.Infrastructure.Services.InputService;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private float _damage;

        [SerializeField] private Transform _gun;
        [SerializeField] private HeroProjectilePool _heroProjectilePool;
        [SerializeField] private Sprite _projectileSprite;

        private IInputService _inputService;

        private void Awake() =>
            _inputService = AllServices.Container.Service<IInputService>();

        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (_inputService.IsAttackButtonUp())
            {
                CreateProjectile();
            }
        }

        private void CreateProjectile()
        {
            ProjectileBase projectile = _heroProjectilePool.TakeProjectileFromPool();
            projectile.transform.position = _gun.position;
            projectile.Construct(_heroProjectilePool, _damage);
            projectile.AddForce(transform.right);
            projectile.AddSprite(_projectileSprite);
        }
    }
}