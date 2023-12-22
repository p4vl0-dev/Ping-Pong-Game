using UnityEngine;

public class PlayerController : MonoBehaviour, IControllable
{
    [Range(0, 100)] [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody2d;
    private Vector2 _localDirection;
    private const float speedCorrection = 100f;
    
    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2d.velocity = _localDirection * _speed * speedCorrection * Time.fixedDeltaTime;
    }

    public void ReadDirection(Vector2 readingVector)
    {
        _localDirection = readingVector;
    }
}
