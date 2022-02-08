using Assets.Scripts.Infrastructure.Services.InputService;
using UnityEngine;

namespace Assets.Scripts.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroFly : MonoBehaviour
    {
        [SerializeField] private float _upForce;
        private Rigidbody2D _rigidbody;
        private IInputService _inputService;
        private void Awake()
        {
            _inputService = AllServices.Container.Service<IInputService>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_inputService.IsJumpButtonUp())
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _upForce);
            }
        }


    }
}