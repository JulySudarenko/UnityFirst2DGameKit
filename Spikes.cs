using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int _spikesDamage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<EllenHealth>().Hurt(_spikesDamage);
        }
    }
}
