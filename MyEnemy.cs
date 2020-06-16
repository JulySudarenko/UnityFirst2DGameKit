using UnityEngine;


internal class MyEnemy : MonoBehaviour
{
    #region Fields

    [HideInInspector] public float Movement;
    [HideInInspector] public bool IsForward = true;
    [HideInInspector] public bool IsAttack = false;
    
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private int _steps;
    [SerializeField] private int _health = 2;
    [SerializeField] private int _attackDamage;

    private Vector3 _startPosition;
    private Vector3 _moveDirection = Vector3.zero;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _startPosition = gameObject.transform.position;
        _moveDirection = Vector3.left;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<EllenHealth>().Hurt(_attackDamage);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            CheckPosition(collision.gameObject.transform.position.x);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            CheckPosition(collision.gameObject.transform.position.x);
        }
    }

    #endregion


    #region Methods

    public void Hurt(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void MoveDirection()
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
        Movement = _moveDirection.x * _speed;
    }

    public void EnemyAttack(GameObject hit)
    {
        if (hit.CompareTag("Player"))
        {
            IsAttack = true;
            transform.position += _moveDirection * _attackSpeed * Time.deltaTime;
            Movement = _moveDirection.x * _attackSpeed;
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
        {
            TurnRight();
        }
        else if (transform.position.x < positionX)
        {
            TurnLeft();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    #endregion
}