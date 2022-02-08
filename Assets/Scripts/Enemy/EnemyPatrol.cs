using UnityEngine;

namespace Assets.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyPatrol : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private float _moveSpeed;

        [SerializeField] private float _patrolTimerMax;
        private float _patrolTimer;
        private bool _isPatroling;

        private Quaternion _rotation;
        private Rigidbody2D _rigidbody;

        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody2D>();

        private void Start()
        {
            EnablePatrol();
            ResetTimer();
            ChangeDirection(-_speed);
            _rotation = transform.rotation;            
        }

        private void Update()
        {
            if (_isPatroling)
            {
                UpdateTimer();
                Move();
                ChangeDirection();
            }
        }

        public void EnablePatrol() => 
            _isPatroling = true;

        public void DisablePatrol() => 
            _isPatroling = false;

        private void ChangeDirection()
        {
            if(TimerIsUp())
            {
                Flip();
                ResetTimer();
            }
        }

        private void Move() => 
            _rigidbody.velocity = new Vector2(_moveSpeed, _rigidbody.velocity.y);

        private void Flip()
        {
            if(transform.rotation == _rotation)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
                ChangeDirection(_speed);
            }
            else
            {
                transform.rotation = _rotation;
                ChangeDirection(-_speed);
            }
        }

        private void ChangeDirection(float speed) => 
            _moveSpeed = speed;

        private void UpdateTimer()
        {
            if(TimerIsUp() == false)
            {
                _patrolTimer -= Time.deltaTime;
            }
        }

        private bool TimerIsUp() =>
            _patrolTimer <= 0;

        private void ResetTimer() => 
            _patrolTimer = _patrolTimerMax;
    }
}
