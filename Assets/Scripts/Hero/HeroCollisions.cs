using UnityEngine;

namespace Assets.Scripts.Hero
{

    [RequireComponent(typeof(HeroAnimator))]
    public class HeroCollisions : MonoBehaviour
    {
        private float _rayDistance = 0.5f;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _jetpackSmoke;
        private HeroAnimator _animator;

        private void Awake() => 
            _animator = GetComponent<HeroAnimator>();

        private void Update() => 
            CheckGround();

        private void CheckGround()
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, _groundLayer);

            if(raycastHit.collider != null)
            {
                _animator.PlayRun();
                _jetpackSmoke.gameObject.SetActive(false);
            }
            else
            {
                _animator.PlayFly();
                _jetpackSmoke.gameObject.SetActive(true);
            }
        }
    }
}
