using UnityEngine;

public class EllenControl : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _startBulletTransform;
    private Vector3 _moveDirection = Vector3.zero;

    #endregion


    #region UnityMethods

    private void Start()
    {

    }

    private void Update()
    {
        _moveDirection.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire1")) Fire();
    }

    private void FixedUpdate()
    {
        transform.position += _moveDirection * _speed * Time.deltaTime;
    }

    #endregion


    #region Methods

    private void Fire()
    {
        Instantiate(_bullet, _startBulletTransform.position, _startBulletTransform.rotation);
    }

    #endregion

}
