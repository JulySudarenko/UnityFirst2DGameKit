using UnityEngine;


public class Mine : MonoBehaviour
{
    #region Field

    [SerializeField] private GameObject _mineExplosionEffect;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _mineForce;
    [SerializeField] private int _mineDamage;
    [SerializeField] private int _mineThrow;

    private Rigidbody2D _rigidbody;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(transform.right * _mineThrow, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Bullet"))
        {
            MineDetonate();
        }
    }

    #endregion


    #region Methods

    private void MineDetonate()
    {
        Collider2D[] victims = Physics2D.OverlapCircleAll(transform.position, _mineForce, _mask);
        ExplosionEffect();

        for (int i = 0; i < victims.Length; i++)
        {
            ExplosionDamage(victims[i]);
        }

        Destroy(gameObject);
    }

    private void ExplosionDamage(Collider2D victim)
    {
        Vector3 direction = victim.transform.position - transform.position;
        victim.attachedRigidbody.AddForce((direction.normalized * _mineForce - victim.transform.position), ForceMode2D.Impulse);
        print(victim.name);

        if (victim.CompareTag("Player"))
        {
            victim.GetComponent<EllenHealth>().Hurt(_mineDamage);
        }

        else if (victim.CompareTag("Enemy"))
        {
            victim.GetComponent<MyEnemy>().Hurt(_mineDamage);
        }
    }

    private void ExplosionEffect()
    {
        var explosion = Instantiate(_mineExplosionEffect, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.GetComponent<AudioPlayer>().PlaySound();
        Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
    }

    #endregion
}
