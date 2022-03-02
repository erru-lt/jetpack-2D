using UnityEngine;

namespace Assets.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMove : MonoBehaviour
    {
        public float MoveSpeed { get; set; }

        [SerializeField] private Rigidbody2D _rigidbody;

        private void FixedUpdate() => 
            Move();

        private void Move() => 
            _rigidbody.velocity = new Vector2(-MoveSpeed, _rigidbody.velocity.y);
    }
}
