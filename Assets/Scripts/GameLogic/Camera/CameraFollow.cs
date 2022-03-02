using UnityEngine;

namespace Assets.Scripts.GameLogic.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void LateUpdate()
        {
            if (_target == null) return;

            FollowTarget();
        }

        public void SetTarget(Transform target) =>
            _target = target;

        private void FollowTarget() =>
           transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
    }
}