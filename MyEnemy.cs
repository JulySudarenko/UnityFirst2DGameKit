using UnityEngine;


internal class MyEnemy : MonoBehaviour
{
    #region Fields

    public float Movement;
    public bool IsForward = true;
    public bool IsAttack;

    [SerializeField] private int _steps;
    [SerializeField] private int _health = 2;
    [SerializeField] private int _attackDamage;
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _attackSpeed;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rigitbody;

    private Vector3 _startPosition;
    private Vector3 _moveDirection = Vector3.zero;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _rigitbody = GetComponent<Rigidbody2D>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _startPosition = gameObject.transform.position;
        _moveDirection = Vector3.right;
    }

    private void Update()
    {
        Movement = _moveDirection.x * _speed;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<EllenHealth>().Hurt(_attackDamage);
            print("Damage!");
            //IsAttack = true;
        }

        else if (collision.gameObject.CompareTag("Wall"))
            CheckPosition(collision.gameObject.transform.position.x);
    }

    public void MoveDirection()
    {
        if (transform.position.x > (_startPosition.x + _steps))
        {
            TurnLeft();
        }

        else if (transform.position.x < _startPosition.x)
        {
            TurnRight();
        }
    }

    public void Patrol()
    {
        MoveDirection();
        transform.position += _moveDirection * _speed * Time.deltaTime;
        IsAttack = false;
    }

    public void EnemyAttack(GameObject hit)
    {
        if (hit.CompareTag("Player"))
        {
            IsAttack = true;
            print("Can see!");
            transform.position += _moveDirection * _attackSpeed * Time.deltaTime;
        }

    }

    public void TurnLeft()
    {
        _moveDirection = Vector3.left;
        IsForward = false;
        Flip();
    }

    public void TurnRight()
    {
        _moveDirection = Vector3.right;
        IsForward = true;
        Flip();
    }

    public void Flip()
    {
        Vector3 vector = Vector3.zero;
        vector.y = IsForward ? 0 : 180;
        transform.rotation = Quaternion.Euler(vector);
    }

    private void CheckPosition(float positionX)
    {
        if (transform.position.x > positionX)
            TurnRight();

        if (transform.position.x < positionX)
            TurnLeft();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    #endregion
}