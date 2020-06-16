using UnityEngine;


public class DoorAnimation : MonoBehaviour
{
    private Animator _animator;

    #region UnityMethods

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        DoorOpening();
    }

    #endregion


    #region UnityMethods

    private void DoorOpening()
    {
        _animator.SetBool("isOpen", true);
    }

    #endregion
}
