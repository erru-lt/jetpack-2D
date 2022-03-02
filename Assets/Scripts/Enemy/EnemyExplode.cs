using Assets.Scripts.GameLogic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyExplode : MonoBehaviour
    {
        public float Damage { get; set; }

        private bool _isExploded;

        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private Transform _explodePosition;
        [SerializeField] private FX _explodeFx;
        private Transform _target;
       
        public void Construct(Transform target) => 
            _target = target;

        private void Start() => 
            _triggerObserver.TriggerEnter += Explode;

        private void OnDestroy() => 
            _triggerObserver.TriggerEnter -= Explode;
         
        private void Explode()
        {
            if (_isExploded) return;

            _isExploded = true;

            _target.GetComponent<IHealth>().TakeDamage(Damage);
            Die();
            SpawnFx();
        }

        private void Die() => 
            Destroy(gameObject);

        private void SpawnFx() => 
            _explodeFx.SpawnFx(_explodePosition.position);
    }
}
