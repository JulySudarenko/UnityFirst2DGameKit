using UnityEngine;


public class MonsterSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _enemyCountity;

    #endregion


    #region UnityMethods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int counter = 0;
        if (collision.gameObject.CompareTag("Player"))
        {
            while (counter < _enemyCountity)
            {
                Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
                counter++;
            }
        }
    }

    #endregion
}
