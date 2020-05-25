using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    /// <summary>
    /// After starting the scrimmer, we start the scene about the end of the game
    /// </summary>
    void Start()
    {
        StartCoroutine(Returns());

        //Wait for seconds real time
        IEnumerator Returns()
        {
            yield return new WaitForSecondsRealtime(1.5f);
            Cursor.visible = true;
            SceneManager.LoadScene("ReturnMenu", LoadSceneMode.Single);
        }
    }
}
