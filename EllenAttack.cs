using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;


public sealed class EllenAttack : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _mine;
    [SerializeField] private GameObject _bulletSound;
    [SerializeField] private Transform _startBulletTransform;
    [SerializeField] private Transform _mineStartTransform;
    [SerializeField] private int _mineCountity;

    private EllenInventory _takenObject;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _takenObject = GetComponentInChildren<EllenInventory>();
        _takenObject.SetMineQuontity(_mineCountity);
    }

    private void Update()
    {
        Fire();
        Mine();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mine"))
        {
            _mineCountity++;
            _takenObject.SetMineQuontity(_mineCountity);
        }
    }

    #endregion


    #region Methods

    private void Fire()
    {
        if (Input.GetButtonDown("Fire3") || CrossPlatformInputManager.GetButtonDown("Fire"))
        {
            Instantiate(_bullet, _startBulletTransform.position, _startBulletTransform.rotation);
            _bulletSound.GetComponent<AudioPlayer>().PlaySound();
        }

    }

    private void Mine()
    {
        if (_mineCountity > 0)
        {
            if (Input.GetButtonDown("Fire2") || CrossPlatformInputManager.GetButtonDown("Mine"))
            {
                Instantiate(_mine, _mineStartTransform.position, _mineStartTransform.transform.rotation);
                _mineCountity--;
                _takenObject.SetMineQuontity(_mineCountity);
            }
        }
    }

    #endregion
}
