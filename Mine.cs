using System.Collections.Generic;
using UnityEngine;


public class Mine : MonoBehaviour
{
    #region Field

    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _mineForce;
    [SerializeField] private int _mineDamage;

    #endregion


    #region UnityMethods

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D victim = collision.rigidbody;
        MineDetonate(victim);
    }

    #endregion


    #region Methods

    private void MineDetonate(Rigidbody2D victim)
    {

        Collider2D hit = Physics2D.OverlapCircle(transform.position, _mineForce, _mask);
        Vector3 direction = hit.transform.position - transform.position;       
        victim.AddForce(direction * _mineForce, ForceMode2D.Impulse);
        
        //List<Rigidbody2D> rbHit = new List<Rigidbody2D>();
        //rbHit.Add(hit.attachedRigidbody);

        //for (int i = 0; i < rbHit.Count; i++)
        //{
        //    rbHit[i].AddForce(direction * _mineForce, ForceMode2D.Impulse);
        //    print(rbHit[i].name);
        //}

        Destroy(gameObject);
        print(victim.name);
    }

    #endregion
}
