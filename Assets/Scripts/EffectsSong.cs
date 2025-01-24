using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsSong : MonoBehaviour
{
    [SerializeField] AudioClip[] songs;
    AudioSource ControlSongs;
    player player;

    void Start()
    {
        ControlSongs = GetComponent<AudioSource>();
        ControlSongs.loop = false;

        player = FindObjectOfType<player>();
    }
    // void Update()
    // {
        
    // }

    public void Bonk()
    {
        AudioClip clip = songs[0];
        ControlSongs.PlayOneShot(clip);
    }

    public void Hit()
    {
        AudioClip clip = songs[1];
        ControlSongs.PlayOneShot(clip);
    }

    public void levelUp()
    {
        AudioClip clip = songs[2];
        ControlSongs.PlayOneShot(clip);
    }
    public void addLife()
    {
        AudioClip clip = songs[3];
        ControlSongs.PlayOneShot(clip);
    }
}
