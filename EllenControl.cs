using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using System;

public class EllenControl : MonoBehaviour
{
    #region Fields

    [HideInInspector] public float Movement;
    [HideInInspector] public bool IsGrounded;

    [SerializeField] private LayerMask _mask;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpForceMax;

    private Rigidbody2D _rigidbody;
    private Vector3 _moveDirection = Vector3.zero;
    private float _groundDistance = 0.2f;
    private bool _isForward = true;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveDirection();
        Jump();
    }

    private void FixedUpdate()
    {
        CheckGround();
        Move();
    }

    #endregion


    #region Methods

    private void MoveDirection()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");

        if (_moveDirection.x == 0.0f)
        {
            _moveDirection.x = CrossPlatformInputManager.GetAxis("Horizontal");
        }

        if (IsGrounded)
        {
            Movement = _moveDirection.x;
        }
    }

    private void Move()
    {
        _rigidbody.transform.position += _moveDirection * _speed * Time.deltaTime;

        if (_moveDirection.x > 0 && !_isForward)
        {
            Flip();
        }
        else if (_moveDirection.x < 0 && _isForward)
        {
            Flip();
        }

    }

    private void Flip()
    {
        _isForward = !_isForward;
        Vector3 vector = Vector3.zero;
        vector.y = _isForward ? 0 : 180;
        transform.rotation = Quaternion.Euler(vector);
    }

    private void Jump()
    {
        if (IsGrounded)
        {
            if (Input.GetButtonDown("Jump") || CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _groundDistance, _mask);

        if (hit)
        {
            IsGrounded = true;
        }

        else
        {
            IsGrounded = false;
        }
    }

    #endregion
}
