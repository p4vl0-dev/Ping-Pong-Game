using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidBody2D;
    private Vector2 _direction;

    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _direction = new Vector2(-1, Random.Range(-100, 100) * 0.01f);
        print(_direction.y);
    }

    void FixedUpdate()
    {
        _rigidBody2D.velocity = _direction * _speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _direction = Vector2.Reflect(_direction, collision.contacts[0].normal);

        Rigidbody2D otherRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

        if (otherRigidbody != null)
        {
            _direction += otherRigidbody.velocity.normalized;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        
    }
}
