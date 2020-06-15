using UnityEngine;


public class EllenHealth : MonoBehaviour
{
    #region Fields

    [SerializeField] private int _health;
    [SerializeField] private int _healthPerAid;
    private EllenInventory _takenObject;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _takenObject = GetComponentInChildren<EllenInventory>();
        _takenObject.SetHealthBar(_health);
        _takenObject.SetHealth(_health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            AidPickUp();
            _takenObject.SetHealthBar(_health);
        }
    }

    #endregion


    #region Methods

    private void AidPickUp()
    {
        _health += _healthPerAid;
        _takenObject.SetHealth(_health);
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        _takenObject.SetHealth(_health);
        _takenObject.SetHealthBar(_health);

        if (_health <= 0)
        {
            print("Ellen is dead");
        }
    }

    #endregion
}
