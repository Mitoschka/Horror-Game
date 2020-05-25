using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscInput : MonoBehaviour
{

    static public bool gameIsPaused = false;

    public Slider senseValue;
    public Slider musicValue;

    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    /// <summary>
    /// Escape press handling
    /// </summary>
    private void Update()
    {
        MouseLook firstOther = GameObject.Find("PlayerCamera").GetComponent<MouseLook>();
        MouseLook secondOther = GameObject.Find("Player").GetComponent<MouseLook>();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Cursor.visible = false;
                Continue();
            }
            else
            {
                Cursor.visible = true;
                Pause(firstOther, secondOther);
            }
        }
    }

    /// <summary>
    /// Processing when a button is pressed 'Escape' or 'Continue'
    /// </summary>
    public void Continue()
    {
        MouseLook firstOther = GameObject.Find("PlayerCamera").GetComponent<MouseLook>();
        MouseLook secondOther = GameObject.Find("Player").GetComponent<MouseLook>();

        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        firstOther.enabled = true;
        secondOther.enabled = true;
        gameIsPaused = false;
    }

    /// <summary>
    /// Processing when a button is pressed 'Escape'
    /// </summary>
    /// <param name="firstOther"> Appeal to script MouseLook for PlayerCamera </param>
    /// <param name="secondOther"> Appeal to script MouseLook for Player </param>
    void Pause(MouseLook firstOther, MouseLook secondOther)
    {
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        firstOther.enabled = false;
        secondOther.enabled = false;
        gameIsPaused = true;
    }

    /// <summary>
    /// Processing when a button is pressed 'NewGame'
    /// </summary>
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Processing when a button is pressed 'Exit'
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Processing when a button is pressed 'Options'
    /// </summary>
    public void Options()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    /// <summary>
    /// Processing when a button is pressed 'Return'
    /// </summary>
    public void Return()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

    /// <summary>
    /// Processing when a button is pressed 'Reset'
    /// </summary>
    public void ResetValues()
    {
        senseValue.value = 9;
        musicValue.value = 15;
    }
}