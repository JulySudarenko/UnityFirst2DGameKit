using UnityEngine;

public class SecretSwitcher : MonoBehaviour
{
    #region Field

    [SerializeField] private GameObject _switcherOff;
    [SerializeField] private GameObject _switcherOn;
    [SerializeField] private GameObject _controlPlatform;

    private bool _isOn = false;

    #endregion


    #region UnityMethods

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
			PlatformEngine platform = _controlPlatform.GetComponent<PlatformEngine>();
            platform.PlatformStart();
            Destroy(_switcherOff);
            //_switcherOff.GetComponent<SpriteMaskInteraction>(); ?
        }
    }

    #endregion
}
