using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public AudioClip music;
    private new AudioSource audio;
    private float speed = 2.0f;

    // Start is called before the first frame update
    /// <summary>
    /// Getting the object component for audiosource
    /// Screaming sound start
    /// </summary>
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(music);
    }

    // Update is called once per frame
    /// <summary>
    /// The movement of the camera towards the monster, when starting a scene with a screamer
    /// </summary>
    void Update()
    {

        transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
    }
}
