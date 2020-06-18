using UnityEngine;


public class CheckKey : MonoBehaviour
{
    #region Field

    [SerializeField] private GameObject _door;
    [SerializeField] private string _message;

    private bool _isOpen = false;

    #endregion


    #region UnityMethods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInChildren<EllenInventory>() && _isOpen == false)
        {
            var inventory = collision.GetComponentInChildren<EllenInventory>();

            if (inventory.HasKey == true)
            {
                var opening = _door.GetComponent<DoorAnimation>();
                opening.DoorOpening();
                _isOpen = true;
            }
            else
            {
                inventory.HelpMessage(_message);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponentInChildren<EllenInventory>())
        {
            var inventory = collision.GetComponentInChildren<EllenInventory>();
            inventory.HelpMessage(null);
        }
    }

    #endregion
}
