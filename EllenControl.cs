using UnityEngine;


public class EllenControl : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _startBulletTransform;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _jumpTime;

    private Vector3 _moveDirection = Vector3.zero;
    private bool _isForvard = true;
    private float _deltaJumpTime = 0.0f;

    #endregion


    #region UnityMethods

    private void Start()
    {

    }

    private void Update()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && _moveDirection.y == 0)
            Jump(true);

        if (Input.GetButtonDown("Fire1")) 
            Fire();
    }

    private void FixedUpdate()
    {
        transform.position += _moveDirection * _speed * Time.deltaTime;

        if (_moveDirection.x > 0 && !_isForvard)
            Flip();
        else if (_moveDirection.x < 0 && _isForvard)
            Flip();

        _deltaJumpTime += Time.deltaTime;
        if (_deltaJumpTime >= _jumpTime ) 
            Jump(false);
    }

    #endregion


    #region Methods

    private void Fire()
    {
        Instantiate(_bullet, _startBulletTransform.position, _startBulletTransform.rotation);
    }

    private void Flip()
    {
        _isForvard = !_isForvard;
        Vector3 vector = Vector3.zero;

        vector.y = _isForvard ? 0 : 180;

        //if (_isForvard)
        //    vector.y = 0;
        //else
        //    vector.y = 180;
        transform.rotation = Quaternion.Euler(vector);
    }

    private void Jump(bool switcherOnOff)
    {
        _moveDirection.y = switcherOnOff ? _jumpSpeed : 0;

        _deltaJumpTime = 0.0f;
    }

    #endregion
}
