
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 0.5f;
    [SerializeField] Transform _segmentPrefab;

    List<Transform> _segmentList = new List<Transform>();

 

    float _moveTime;
    private float _moveTimeCounter;
    private Vector2Int _currentDirection;
    private Vector2Int _nextDirection;
    private Vector2Int _rightVector = Vector2Int.right;
    private Vector2Int _leftVector = Vector2Int.left;
    private Vector2Int _downVector = Vector2Int.down;
    private Vector2Int _upVector = Vector2Int.up;
    Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

    }
    private void OnEnable()
    {
        _segmentList.Add(transform);
        _nextDirection = _rightVector;
        _moveTime = 1 / _moveSpeed;
        _moveTimeCounter = _moveTime;
        Grow();
        _segmentList[1].tag = "Untagged";
    }
    private void Update()
    {
        if(_currentDirection == _upVector || _currentDirection == _downVector)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _nextDirection = _leftVector;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _nextDirection = _rightVector;
            }
        }
        if (_currentDirection == _rightVector || _currentDirection == _leftVector)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _nextDirection = _downVector;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _nextDirection = _upVector;
            }
        }

       
        _moveTimeCounter -= Time.deltaTime;
        
    }
    private void FixedUpdate()
    {
        if(_moveTimeCounter<0)
        {
            _currentDirection = _nextDirection;
            _rb.MovePosition(_rb.position + _nextDirection);
            for (int i = _segmentList.Count -1; i >0; i--)
            {
                _segmentList[i].position = _segmentList[i - 1].position;
            }
            CheckTeleport();
            _moveTimeCounter = _moveTime;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Food"))
        {
            Grow();
        }
        if(collision.CompareTag("Obstacle"))
        {
           
            GameManager.Instance.GameOver();
        }
    }
    private void Grow()
    {
        Transform newSegment = Instantiate(_segmentPrefab);
        newSegment.position = _segmentList[_segmentList.Count - 1].position;
        _segmentList.Add(newSegment);
    }
    private void CheckTeleport()
    {
        if (_rb.position.x < BoundaryHandler.Instance.MinBoundaryPointVector.x)
            _rb.MovePosition(new Vector2Int(BoundaryHandler.Instance.MaxBoundaryPointVector.x, Mathf.RoundToInt(_rb.position.y)));
        if (_rb.position.x > BoundaryHandler.Instance.MaxBoundaryPointVector.x)
            _rb.MovePosition(new Vector2Int(BoundaryHandler.Instance.MinBoundaryPointVector.x, Mathf.RoundToInt(_rb.position.y)));
        if (_rb.position.y > BoundaryHandler.Instance.MaxBoundaryPointVector.y)
            _rb.MovePosition(new Vector2Int(Mathf.RoundToInt(_rb.position.x), BoundaryHandler.Instance.MinBoundaryPointVector.y));
        if (_rb.position.y < BoundaryHandler.Instance.MinBoundaryPointVector.y)
            _rb.MovePosition(new Vector2Int(Mathf.RoundToInt(_rb.position.x), BoundaryHandler.Instance.MaxBoundaryPointVector.y));
    }
}
