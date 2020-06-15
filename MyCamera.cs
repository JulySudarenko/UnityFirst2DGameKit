using UnityEngine;


public class MyCamera : MonoBehaviour
{
    #region Field

    [SerializeField] private GameObject _playerEllen;
    [SerializeField] private Vector3 _deltaCameraPosition;

    #endregion


    #region UnityMethods

    private void FixedUpdate()
    {
       gameObject.transform.position = _playerEllen.transform.position + _deltaCameraPosition;
    }

    #endregion
}
