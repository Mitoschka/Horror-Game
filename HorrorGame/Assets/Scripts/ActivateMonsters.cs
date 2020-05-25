using UnityEngine;

public class ActivateMonsters : MonoBehaviour
{
    /// <summary>
    /// The distance at which the camera detects an object
    /// </summary>
    private float lenght = 12;

    /// <summary>
    /// The implementation of the beam emitted from the center of the camera, for the recognition of monsters
    /// </summary>
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay( new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));
        Debug.DrawRay(transform.position, ray.direction * lenght);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitGameObject = hit.transform.gameObject;
            ReactiveTarget target = hitGameObject.GetComponent<ReactiveTarget>();
            if (target != null)
            {
                target.ReactToTarget();
            }
        }
    }
}
