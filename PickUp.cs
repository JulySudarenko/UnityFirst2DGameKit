using UnityEngine;


internal class PickUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Remove();
        }
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}
