using UnityEngine;


public sealed class EnemyView : MonoBehaviour
{
    #region Fields

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _distance;

    private MyEnemy _enemy;
    private RaycastHit2D _hit;
    private float _viewUp = 1.3f;

    #endregion


    #region UnityMethods

    private void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            _enemy = gameObject.GetComponent<MyEnemy>();
        }
    }

    public void Update()
    {
        VisionForward();
    }

    #endregion


    #region Methods

    private void VisionForward()
    {
        Vector3 viewStart = new Vector3(transform.position.x, transform.position.y + _viewUp, transform.position.z);
 
        if (_enemy.IsForward)
        {
            _hit = Physics2D.Raycast(viewStart, Vector2.right, _distance, _layerMask);
        }
        else
        {
            _hit = Physics2D.Raycast(viewStart, Vector2.left, _distance, _layerMask);
        }

        if (_hit && _hit.collider.CompareTag("Player"))
        {
            _enemy.EnemyAttack(_hit.collider.gameObject);
        }
        else
        {
            _enemy.Patrol();
        }
    }
    #endregion
}
