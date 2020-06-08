using UnityEngine;


public class EllenAnimation : MonoBehaviour
{
    #region Fields

    private Animator _animator;
    private EllenControl _player;

    #endregion


    #region UnityMethods

    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            _player = gameObject.GetComponent<EllenControl>();
        }
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SetSpeed(_player.Movement);
        //SetJump(_player.IsGrounded);
    }

    #endregion


    #region Methods

    private void SetSpeed(float speed)
    {
        _animator.SetFloat("Speed", Mathf.Abs(speed));
    }

    private void SetJump(bool jump)
    {
        jump = !jump;
        _animator.SetBool("Jump", jump);
    }

    #endregion
}
