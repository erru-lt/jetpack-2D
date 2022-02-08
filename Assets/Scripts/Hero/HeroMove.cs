using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rigidbody;

    private void Awake() => 
        _rigidbody = GetComponent<Rigidbody2D>();

    private void FixedUpdate() => 
        Move();

    private void Move() => 
        _rigidbody.velocity = new Vector2(_moveSpeed, _rigidbody.velocity.y);
}
