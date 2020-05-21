using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip sound;

    private AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSrc.PlayOneShot(sound);
    }
}
