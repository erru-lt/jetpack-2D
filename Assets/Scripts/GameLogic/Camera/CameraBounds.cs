using UnityEngine;

namespace Assets.Scripts.GameLogic.Camera
{
    public class CameraBounds : MonoBehaviour
    {
        [SerializeField] private float minYvalue = -8;
        [SerializeField] private float maxYvalue = 5;

        [SerializeField] private Transform _levelTransitionPoint;

        private void LateUpdate() => 
            CameraMovementBounds();

        private void CameraMovementBounds() => 
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, 0, _levelTransitionPoint.position.x),
                Mathf.Clamp(transform.position.y, minYvalue, maxYvalue),
                transform.position.z);
    }
}
