using UnityEngine;


internal class PlatformEngine : MonoBehaviour
{
    #region Field

    [SerializeField] private Vector3 _finishPosition;
    [SerializeField] private int _speed;

    private Rigidbody2D _rigidbody;
    private Vector3 _startPosition;
    private Vector3 _moveDirection = Vector3.zero;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _startPosition = gameObject.transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlatformMoveDirection();
        MovePosition();
    }

    #endregion


    #region Methods

    public void PlatformStartX()
    {
        _moveDirection.x = _speed;
    }

    public void PlatformStartY()
    {
        _moveDirection = Vector3.down;
    }

    private void PlatformMoveDirection()
    {
        if (transform.position.x > _finishPosition.x)
        {
            _moveDirection.x *= -1;
        }
        else if (transform.position.x < _startPosition.x)
        {
            _moveDirection.x *= -1;
        }


        if (transform.position.y > _finishPosition.y)
        {
            _moveDirection = Vector3.down;
        }
        else if (transform.position.y < _startPosition.y)
        {
            _moveDirection = Vector3.up;
        }
    }

    private void MovePosition()
    {
        var currentPosition = transform.position;
        var nextPosition = _moveDirection * _speed * Time.deltaTime;
        _rigidbody.MovePosition(currentPosition + nextPosition);
    }

    #endregion
}
