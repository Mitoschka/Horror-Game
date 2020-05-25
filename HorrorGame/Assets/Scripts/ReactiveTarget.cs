using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReactiveTarget : MonoBehaviour
{
    public GameObject monster;
    public new Camera camera;

    /// <summary>
    /// Running a scene with a screamer
    /// </summary>
    public void ReactToTarget()
    {
        StartCoroutine(Return());
       
        //Wait for seconds real time
        IEnumerator Return()
        {
            yield return new WaitForSecondsRealtime(1.0f);
            SceneManager.LoadScene("Horror", LoadSceneMode.Single);
        }
    }
}
