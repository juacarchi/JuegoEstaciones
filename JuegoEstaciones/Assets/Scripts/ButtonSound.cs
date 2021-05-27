using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSound;
    

    public void PlayButtonSound()
    {
        audioSource.clip = buttonSound;
        audioSource.Play();
    }
}
