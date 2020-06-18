using UnityEngine;


public class DoorAnimation : MonoBehaviour
{
    private Animator _animator;

    #region UnityMethods

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    #endregion


    #region Methods

    public void DoorOpening()
    {
        _animator.SetBool("isOpen", true);
        gameObject.GetComponent<AudioPlayer>().PlaySound();
    }

    #endregion
}
