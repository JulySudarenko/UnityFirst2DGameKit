using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class EllenInventory : MonoBehaviour
{
    #region Field

    [HideInInspector] public bool HasKey = false;

    [SerializeField] private TMP_Text _textMineCount;
    [SerializeField] private TMP_Text _textHealth;
    [SerializeField] private Text _helpingMessage;
    [SerializeField] private Image _key;
    [SerializeField] private Image _healthBar;
    [SerializeField] private float _maxHealth;

    #endregion


    #region UnityMethods

    private void Start()
    {
        ShowKeyImage(false);
        SetHealth(_maxHealth);
    }

    #endregion


    #region Methods

    public void SetHealthBar(float health)
    {
        _healthBar.fillAmount = health / _maxHealth;
    }

    public void SetHealth(float health)
    {
        _textHealth.text = health.ToString();
    }

    public void SetMineQuontity(int mineQuontity)
    {
        _textMineCount.text = mineQuontity.ToString();
    }

    public void ShowKeyImage(bool isTaken)
    {
        _key.enabled = isTaken;
        HasKey = true;
    }

    public void HelpMessage(string message)
    {
        _helpingMessage.text = message;
    }

    #endregion
}
