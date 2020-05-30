using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPoint;

    #endregion


    #region UnityMethods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
        }
    }

    #endregion

}
