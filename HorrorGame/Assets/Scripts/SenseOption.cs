using UnityEngine;
using UnityEngine.UI;

public class SenseOption : MonoBehaviour
{
    /// <summary>
    ///  Mouse sensitivity controls
    /// </summary>
    public Slider senseValue;

    /// <summary>
    /// Mouse sensitivity settings
    /// </summary>
    public void Sense()
    {
        GameObject player = GameObject.Find("Player");
        MouseLook playerSense = player.GetComponent<MouseLook>();
        playerSense.sensitivityHor = senseValue.value;
        playerSense.sensitivityVert = senseValue.value;
        GameObject camera = GameObject.Find("PlayerCamera");
        MouseLook cameraSense = camera.GetComponent<MouseLook>();
        cameraSense.sensitivityHor = senseValue.value;
        cameraSense.sensitivityVert = senseValue.value;
    }
}
