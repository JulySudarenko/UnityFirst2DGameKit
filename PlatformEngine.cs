using UnityEngine;

internal class PlatformEngine : MonoBehaviour
{
    #region Field

    [SerializeField] private Vector3 _finishPosition;
    [SerializeField] private int _speed;

    private SpriteRenderer _sprite;
    private Vector3 _startPosition;
    private Vector3 _moveDirection = Vector3.zero;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _startPosition = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        if (transform.position.x >= _finishPosition.x)
            _moveDirection.x *= -1;
        else if (transform.position.x < _startPosition.x)
            _moveDirection.x *= -1;
        transform.position += _moveDirection * _speed * Time.deltaTime;
    }

    #endregion


    #region Methods

    public void PlatformStart()
    {
        _moveDirection.x = _speed;
    }

    #endregion
}
