using UnityEngine;
using UnityEngine.Accessibility;

internal class MyEnemy : MonoBehaviour
{
    #region Fields

    //[SerializeField] private AudioClip _dieMoment;
    [SerializeField] private int _steps;
    [SerializeField] private int _health = 2;
    [SerializeField] private int _attackDamage;
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _attackSpeed;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rigitbody;

    private Vector3 _startPosition;
    private Vector3 _moveDirection = Vector3.zero;
    public bool IsForward = true;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _rigitbody = GetComponent<Rigidbody2D>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _startPosition = gameObject.transform.position;
        _moveDirection.x = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<EllenHealth>();
            print("Damage!");
            player.Hurt(_attackDamage);
        }
    }

    #endregion


    #region Methods

    public void Hurt(int damage)
    {
        _health -= damage;
        _sprite.color = Color.red;

        if (_health <= 0)
        {
            Die();
        }
    }

    public void MoveDirection()
    {
        if (transform.position.x > (_startPosition.x + _steps))
        {
            _moveDirection.x *= -1;
            Flip();
        }

        else if (transform.position.x < _startPosition.x)
        {
            _moveDirection.x *= -1;
            Flip();
        }
    }

    public void Patrol()
    {
        MoveDirection();
        transform.position += _moveDirection * _speed * Time.deltaTime;
    }

    public void EnemyAttack(GameObject hit)
    {
        print("Can see!");
        transform.position += _moveDirection * _attackSpeed * Time.deltaTime;
    }

    private void Flip()
    {
        IsForward = !IsForward;
        Vector3 vector = Vector3.zero;
        vector.y = IsForward ? 0 : 180;
        transform.rotation = Quaternion.Euler(vector);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    #endregion
}