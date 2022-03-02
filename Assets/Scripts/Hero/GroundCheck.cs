using UnityEngine;

namespace Assets.Scripts.Hero
{
    public class GroundCheck : MonoBehaviour
    {
        private readonly float _rayDistance = 0.5f;
        private bool _isGrounded;

        [SerializeField] private LayerMask _groundLayer;
         
        private void Update() => 
            CheckGround();

        public bool IsGrounded() =>
            _isGrounded;

        private void CheckGround()
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, _groundLayer);

            if(raycastHit.collider != null)
            {
                _isGrounded = true;
            }
            else
            {
                _isGrounded = false;
            }
        }
    }
}
