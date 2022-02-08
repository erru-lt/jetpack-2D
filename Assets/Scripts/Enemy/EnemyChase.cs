using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyChase : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        private bool _isChasing;

        [SerializeField] private Transform _target;
        private Rigidbody2D _rigidbody;

        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody2D>();

        private void Update()
        {
            if (_isChasing)
            {
                Chasing();
                LookAtTarget();
            }
        }

        public void EnableChase() => 
            _isChasing = true;

        public void DisableChase() => 
            _isChasing = false;

        private void Chasing()
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);
        }

        private void LookAtTarget()
        {
            if (_target.position.x > transform.position.x)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
}
