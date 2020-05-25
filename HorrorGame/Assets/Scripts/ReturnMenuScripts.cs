using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenuScripts : MonoBehaviour
{
    /// <summary>
    /// Handling the event of clicking on "Play game" in the return menu
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    /// <summary>
    /// Handling the event of clicking on "Exit" in the return menu
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
