using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float speed = 1.0f;
    private float gravity = -4.0f;
    private CharacterController charController;
    public AudioClip firstAudio;
    public AudioClip secondAudio;
    private new AudioSource audio;
    private float timeout;
    private float footSteapTime = 1.0f;
    private bool step = false;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        charController = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        timeout += Time.deltaTime;
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);

        if (Input.GetButton("Horizontal") & timeout >= footSteapTime || Input.GetButton("Vertical") & timeout >= footSteapTime)
        {
            timeout = 0;
            if (step)
            {
                audio.PlayOneShot(secondAudio);
                step = false;
                return;
            }
            if (!step)
            {
                audio.PlayOneShot(firstAudio);
                step = true;
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            speed = 3.0f;
            footSteapTime = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            speed = 1.0f;
            footSteapTime = 1.0f;
        }
    }
}