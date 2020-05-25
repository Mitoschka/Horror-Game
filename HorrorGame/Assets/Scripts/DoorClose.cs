using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    public GameObject obj;

    public AudioClip din;
    public AudioClip music;
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
    /// When the trigger is triggered, the animation starts closing the door, as well as the sound
    /// </summary>
    /// <param name="col">Collider trigger</param>
    void OnTriggerEnter(Collider col)
    {
        obj.GetComponent<Animator>().SetBool("enter", false);
        if (!playAudio)
        {
            audio.PlayOneShot(din);
            playAudio = true;
            StartCoroutine(Return());
        }
        //Wait for seconds real time
        IEnumerator Return()
        {
            yield return new WaitForSecondsRealtime(3.0f);
            audio.PlayOneShot(music);
        }
    }


}