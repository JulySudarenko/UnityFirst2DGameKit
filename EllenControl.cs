using UnityEngine;


public class EllenControl : MonoBehaviour
{
    #region Fields

    public float Movement;
    public bool IsGrounded;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _mine;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private Transform _startBulletTransform;
    [SerializeField] private Transform _mineStartTransform;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpForceMax;
    [SerializeField] private int _mineCountity;

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
        _moveDirection.x = Input.GetAxis("Horizontal");
        if (IsGrounded)
        {
            Movement = _moveDirection.x;
        }

        if (Input.GetButtonDown("Jump"))
            Jump();

        if (Input.GetButtonDown("Fire1"))
            Fire();

        if (Input.GetKeyDown(KeyCode.M))
            MineInstaller();
    }

    private void FixedUpdate()
    {
        _rigidbody.transform.position += _moveDirection * _speed * Time.deltaTime;

        CheckGround();

        if (_moveDirection.x > 0 && !_isForward)
            Flip();
        else if (_moveDirection.x < 0 && _isForward)
            Flip();
    }

    #endregion


    #region Methods

    private void Fire()
    {
        Instantiate(_bullet, _startBulletTransform.position, _startBulletTransform.rotation);
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
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void MineInstaller()
    {
        Instantiate(_mine, _mineStartTransform.position, _mineStartTransform.transform.rotation);
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
