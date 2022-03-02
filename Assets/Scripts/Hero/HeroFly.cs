using Assets.Scripts.Infrastructure.Services.InputService;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    [RequireComponent(typeof(Rigidbody2D), typeof(HeroAnimator))]
    public class HeroFly : MonoBehaviour
    {
        [SerializeField] private float _upForce;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _jetpackSmoke;
        [SerializeField] private HeroAnimator _animator;
        [SerializeField] private GroundCheck _groundCheck;

        private IInputService _inputService;

        public void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void Update() => 
            CheckInput();

        private void CheckInput()
        {
            if (_inputService.IsJumpButtonUp())
            {
                Fly();
            }
            else
            {
                StopFly();
            }
        }

        private void Fly()
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _upForce);
            _animator.PlayFly();
            _jetpackSmoke.gameObject.SetActive(true);
        }

        private void StopFly()
        {
            if (_groundCheck.IsGrounded())
            {
                _animator.PlayRun();
                _jetpackSmoke.gameObject.SetActive(false);
            }
            else
            {
                _animator.PlayIdle();
            }
        }
    }
}