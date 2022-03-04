using Assets.Scripts.GameLogic;
using Assets.Scripts.GameLogic.Pool;
using Assets.Scripts.Infrastructure.Services.InputService;
using Assets.Scripts.Infrastructure.Services.ProgressService;
using Assets.Scripts.StaticData.Projectile;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class HeroAttack : MonoBehaviour
    {
        private float _damage;
       
        [SerializeField] private ProjectileStaticData _projectileStaticData;
        [SerializeField] private Transform _gun;

        private Sprite _projectileSprite;
        private HeroProjectilePool _heroProjectilePool;

        private IInputService _inputService;
        private IProgressService _progressService;
        
        public void Construct(IInputService inputService, HeroProjectilePool heroProjectilePool, IProgressService progressService)
        {
            _inputService = inputService;
            _heroProjectilePool = heroProjectilePool;       
            _progressService = progressService;
        }

        private void Start() => 
            AddAttackStats();

        private void Update() => 
            Shoot();

        public void AddAttackStats()
        {
            if (_progressService.PlayerProgress.PlayerStats.AttackStatsIsEmpty())
            {
                _damage = _projectileStaticData.Damage;
                _projectileSprite = _projectileStaticData.ProjectileSprite;
            }
            else
            {
                _damage = _progressService.PlayerProgress.PlayerStats.Damage;
                _projectileSprite = _progressService.PlayerProgress.PlayerStats.ProjectileSprite;
            }
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