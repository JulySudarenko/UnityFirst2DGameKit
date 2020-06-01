using UnityEditor;
using UnityEngine;


public class EllenHealth : MonoBehaviour
{
    #region Fields

    [SerializeField] private int _health;
    [SerializeField] private int _healthPerAid;
    [SerializeField] private GameObject _heartEllen;
    [SerializeField] private GameObject _heartFullEllen;
    [SerializeField] private GameObject _heartItem;
    [SerializeField] private Vector3 _deltaHeartPosition;

    #endregion


    #region UnityMethods

    private void Start()
    {
        Instantiate(_heartEllen, (gameObject.transform.position + _deltaHeartPosition), Quaternion.Euler(Vector3.zero));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            AidPickUp();

            var heart = collision.gameObject.GetComponent<Heart>();
            heart.Remove();
        }
    }

    #endregion


    #region Methods

    private void AidPickUp()
    {
        _health += _healthPerAid;
        //Instantiate(_heartFullEllen, gameObject.transform.position + _deltaHeartPosition, Quaternion.Euler(Vector3.zero));
        print($"Здоровье Элен: {_health}\n");
    }

    #endregion
}
