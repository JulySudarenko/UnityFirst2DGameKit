using UnityEngine;

public class EllenBullet : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private float _lifeTime = 4.0f;
    [SerializeField] private int _damage = 1;

    #endregion


    #region UnityMethods

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        gameObject.transform.position += transform.right * _speed * Time.deltaTime;
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
