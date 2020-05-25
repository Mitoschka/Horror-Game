using UnityEngine;
using UnityEngine.UI;

public class MusicOption : MonoBehaviour
{
    /// <summary>
    /// Volume control
    /// </summary>
    public Slider audioVolume;

    /// <summary>
    /// The value of sound in the game
    /// </summary>
    public void Volume()
    {
        AudioListener.volume = audioVolume.value - 14;
    }
}
