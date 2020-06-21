using UnityEngine;

public class Key : MonoBehaviour
{
    #region Fields

    private GameObject _player;
    private EllenInventory _takenObject;

    #endregion


    #region UnityMethods

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _player = collision.gameObject;
            _takenObject = _player.GetComponentInChildren<EllenInventory>();

            if (gameObject.CompareTag("Key"))
            {
                _takenObject.ShowKeyImage(true);
                _takenObject.HasKey = true;
            }
        }
    }

    #endregion
}
