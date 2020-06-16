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
        if (collision.gameObject.CompareTag("Player"))
        {
            for(int i = 0; i < _enemyCountity; i++)
            {
                Vector3 random = RandomPoint();
                Instantiate(_enemy, random, _spawnPoint.rotation);
            }
        }
    }

    #endregion


    #region Methods

    private Vector3 RandomPoint()
    {
        Vector3 vector = _spawnPoint.position;
        vector.x += Random.Range(0, 4);
        return vector;
    }

    #endregion
}
