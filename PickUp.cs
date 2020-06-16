using UnityEngine;


public sealed class PickUp : MonoBehaviour
{
    #region UnityMethods

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Remove();
        }
    }

    #endregion


    #region Methods

    private void Remove()
    {
        Destroy(gameObject);
    }

    #endregion
}
