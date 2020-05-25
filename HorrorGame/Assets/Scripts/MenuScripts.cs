using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    /// <summary>
    /// Handling the event of clicking on "Play game" in the main menu
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Handling the event of clicking on "Exit" in the main menu
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
