using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager2 : MonoBehaviour
{
    public static SFXManager2 instance;

    public AudioClip succes;
    public AudioClip fail;
    public AudioClip victory;

    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlaySFX(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
