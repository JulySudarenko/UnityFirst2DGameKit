using UnityEngine;


internal class MyEnemy : MonoBehaviour
{
    #region Fields

    private SpriteRenderer _sprite;
    //[SerializeField] private AudioClip _dieMoment;
    [SerializeField] private int _steps;
    [SerializeField] private int _health = 2;
    [SerializeField] private float _speed = 2.0f;

    private Vector3 _startPositon;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _startPositon = gameObject.transform.position;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        Move();
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

    public void Move()
    {
        if (gameObject.transform.position.x <= _startPositon.x)
            gameObject.transform.position += Vector3.left * _speed * Time.deltaTime;
        if (gameObject.transform.position.x >= _startPositon.x + _steps)
            gameObject.transform.position += Vector3.right * _speed * Time.deltaTime;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    #endregion

}