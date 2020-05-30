using UnityEngine;


internal class MyEnemy : MonoBehaviour
{
    #region Fields

    private SpriteRenderer _sprite;
    [SerializeField] private AudioClip _dieMoment;
    
    [SerializeField] private int _health = 2;
    [SerializeField] private float _speed = 2.0f;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        //MoveLeft();
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

    public void MoveLeft()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
    }

    public void MoveRight()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.World);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    #endregion

}