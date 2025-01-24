using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Songs : MonoBehaviour
{
    [SerializeField] AudioClip[] soundsBackground;

    AudioSource backSongs;
    player player;
    EndGame EndGame;


    void Start()
    {
        backSongs = GetComponent<AudioSource>();
        backSongs.loop = false;

        player = FindObjectOfType<player>();
        EndGame = FindObjectOfType<EndGame>();



        // if(PlayerPrefs.GetInt("iniciou") == 1 && backSongs.isPlaying)
        // {
        //     backSongs.Stop();
        //     StartCoroutine (Pausar());
        //     BackGroundSounds();

        // }

        // if(PlayerPrefs.GetInt("iniciou") == 1 !backSongs.isPlaying)
        // {
        //     StartCoroutine (Pausar());
        // }
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("iniciou") == 1 && !backSongs.isPlaying)
        {
            if(player.andar)
            {
                BackGroundSounds();
            }
            // backSongs.Stop();
            // StartCoroutine (Pausar());BackGroundSounds();

        }
    }

    public void BackGroundSounds()
    {
        if(player.andar)
        {
            AudioClip clip = soundsBackground[UnityEngine.Random.Range(0, soundsBackground.Length)];
            backSongs.PlayOneShot(clip);
        }
        // if(EndGame.mobsKilleds == 15)
        // {
        //     // AudioClip clip = soundsBackground[UnityEngine.Random.Range(0, soundsBackground.Length)];
        //     backSongs.Pause();
        // }
        if(!player.andar)
        {
            backSongs.Pause();
        }

        // backSongs.PlayScheduled(AudioSettings.dspTime + soundsBackground.Length);
    }

    private IEnumerator Pausar()
    {
        yield return new WaitForSeconds (3);
        // andar = true;
        // backSongs.Play();
    }
}
