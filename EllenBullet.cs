using UnityEngine;


public class EllenBullet : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _speed = 20.0f;
    [SerializeField] private float _lifeTime = 4.0f;
    [SerializeField] private int _damage = 1;

    private Rigidbody2D _rigidbody;

    #endregion


    #region UnityMethods

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(transform.right * _speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);
        }

        if (!collision.gameObject.CompareTag("Player")) 
            Destroy(gameObject);
    }

    #endregion
}
