using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameLogic.Pool
{
    public abstract class ProjectilePoolBase : MonoBehaviour
    {
        private readonly int _poolStartSize = 50;

        [SerializeField] protected ProjectileBase _projectilePrefab;

        private Queue<ProjectileBase> _projectiles = new Queue<ProjectileBase>();

        private void Start() =>
            InitializePool();

        public ProjectileBase TakeProjectileFromPool()
        {
            if (_projectiles.Count > 0)
            {
                ProjectileBase projectile = DequeueProjectile();
                return projectile;
            }
            else
            {
                ProjectileBase projectile = CreateProjectile();
                return projectile;
            }
        }

        public void ReturnProjectileToPool(ProjectileBase projectile)
        {
            EnqueueProjectile(projectile);
        }

        private ProjectileBase CreateProjectile() =>
            Instantiate(_projectilePrefab);

        private ProjectileBase DequeueProjectile()
        {
            ProjectileBase projectile = _projectiles.Dequeue();
            projectile.gameObject.SetActive(true);
            return projectile;
        }

        private void EnqueueProjectile(ProjectileBase projectile)
        {
            _projectiles.Enqueue(projectile);
            projectile.gameObject.SetActive(false);
        }

        private void InitializePool()
        {
            for (int i = 0; i < _poolStartSize; i++)
            {
                ProjectileBase projectile = CreateProjectile();
                EnqueueProjectile(projectile);
            }
        }
    }
}

