using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMove : MonoBehaviour
    {
        public float MoveSpeed
        {
            get => _playerStats.MoveSpeed;
            set => _playerStats.MoveSpeed = value;
        }

        [SerializeField] private Rigidbody2D _rigidbody;
        private PlayerStats _playerStats;

        public void Construct(PlayerStats playerStats) =>
            _playerStats = playerStats;

        private void FixedUpdate() =>
            Move();

        private void Move() =>
            _rigidbody.velocity = new Vector2(MoveSpeed, _rigidbody.velocity.y);
    }
}