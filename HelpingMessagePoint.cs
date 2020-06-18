using UnityEngine;


public class HelpingMessagePoint : MonoBehaviour
{
    [SerializeField] private string _message;

    #region UnityMethods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInChildren<EllenInventory>())
        {
            var inventory = collision.GetComponentInChildren<EllenInventory>();
            inventory.HelpMessage(_message);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponentInChildren<EllenInventory>())
        {
            var inventory = collision.GetComponentInChildren<EllenInventory>();
            inventory.HelpMessage(" ");
        }
    }

    #endregion
}
