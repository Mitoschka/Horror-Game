using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject obj;

    public AudioClip din;
    private new AudioSource audio;
    private bool playAudio = false;

    /// <summary>
    /// Getting the object component for audiosource
    /// </summary>
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// When the trigger is triggered, the animation starts opening the door, as well as the sound
    /// </summary>
    /// <param name="col">Collider trigger</param>
    void OnTriggerEnter(Collider col)
    {
        obj.GetComponent<Animator>().SetBool("enter", true);
        if (!playAudio)
        {
            audio.PlayOneShot(din);
            playAudio = true;
        }
    }
}
