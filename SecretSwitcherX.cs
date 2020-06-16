using UnityEngine;


public class SecretSwitcherX : MonoBehaviour
{
    #region Field

    [SerializeField] private GameObject _switcherOff;
    [SerializeField] private GameObject _switcherOn;
    [SerializeField] private GameObject _controlPlatform;

    #endregion


    #region UnityMethods

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            PlatformEngine platform = _controlPlatform.GetComponent<PlatformEngine>();
            platform.PlatformStartX();
            Destroy(_switcherOff);
        }
    }

    #endregion
}
