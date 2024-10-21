using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource SFX;
    public AudioSource Music;
    [Header("Audio Clip")]

    public AudioClip BG;
    public AudioClip pickItem;
    public AudioClip drop;

    public AudioClip Party;
    public AudioClip Destroyed;
    public AudioClip Freeze;

    public AudioClip Star;
    public AudioClip Final;


    private void Start()
    {
        Music.clip = BG;
        Music.Play();
    }

    public void PlayerSFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
