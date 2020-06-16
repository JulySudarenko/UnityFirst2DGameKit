using UnityEngine;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    #region Field

    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private int _nextSceneNumber;
    private bool _isPaused = false;

    #endregion


    #region UnityMethods

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ReturnToGame();
            }
            else
            {
                Pause();
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            LoadLevel(_nextSceneNumber);
        }
    }

    #endregion


    #region Methods

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        _isPaused = true;
    }

    public void ReturnToGame()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        _isPaused = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    #endregion
}
