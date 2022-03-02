using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyChase : MonoBehaviour
    {
        public float MoveSpeed { get; set; }

        private bool _isChasing;

        [SerializeField] private Rigidbody2D _rigidbody;
        private Quaternion _lookRight;
        private Quaternion _lookLeft;
        private Transform _target;
   
        public void Construct(Transform target) => 
            _target = target;

        private void Start()
        {
            _lookRight = new Quaternion(0, 180, 0, 0);
            _lookLeft = new Quaternion(0, 0, 0, 0);
        }

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
            _rigidbody.velocity = new Vector2(direction.x * MoveSpeed, _rigidbody.velocity.y);
        }

        private void LookAtTarget()
        {
            if (_target.position.x > transform.position.x)
            {
                transform.rotation = _lookRight;
            }
            else
            {
                transform.rotation = _lookLeft;
            }
        }
    }
}
