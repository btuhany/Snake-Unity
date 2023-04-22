
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 0.5f;
    float _moveTime;
    private float _moveTimeCounter;

    private Vector2Int _currentDirection;
    private Vector2Int _rightVector = Vector2Int.right;
    private Vector2Int _leftVector = Vector2Int.left;
    private Vector2Int _downVector = Vector2Int.down;
    private Vector2Int _upVector = Vector2Int.up;
    Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentDirection = _rightVector;
        _moveTime = 1 / _moveSpeed;
        _moveTimeCounter = _moveTime;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            _currentDirection = _downVector;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            _currentDirection = _upVector;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _currentDirection = _leftVector;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            _currentDirection = _rightVector;
        }
        _moveTimeCounter -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if(_moveTimeCounter<0)
        {
            _rb.MovePosition(_rb.position + _currentDirection);
            _moveTimeCounter = _moveTime;
        }
    }

}
