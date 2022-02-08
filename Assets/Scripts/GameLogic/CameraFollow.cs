using UnityEngine;

public class CameraFollow : MonoBehaviour
{ 
    [SerializeField] private Transform _target;

    private void LateUpdate()
    {
        if (_target == null) return;

        transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
    }

    public void SetTarget(Transform target) => 
        _target = target;
}
