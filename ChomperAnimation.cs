using UnityEngine;

public class ChomperAnimation : MonoBehaviour
{
    #region Fields

    private Animator _animator;
    private MyEnemy _enemy;

    #endregion


    #region UnityMethods

    private void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            _enemy = gameObject.GetComponent<MyEnemy>();
        }
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        ShowAttack(_enemy.IsAttack);
        SetSpeed(_enemy.Movement);
    }

    #endregion


    #region Methods

    public void SetSpeed(float speed)
    {
        _animator.SetFloat("Speed", Mathf.Abs(speed));
    }

    public void ShowAttack(bool isAttack)
    {
        _animator.SetBool("Attack", isAttack);
    }
    
    #endregion
}
