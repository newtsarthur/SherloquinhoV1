using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class sceneStart : MonoBehaviour
{
    // Start is called before the first frame update

    // public int mobsKilleds;

    public PlayableDirector director;
    public player player;

    public initScene initScene;


    void Start()
    {

        initScene = FindObjectOfType<initScene>();

        // player = GetComponent<player>();
        
        // if(initScene.iniciou >= 1)
        // {
        //     director.Play();
        // }

        // if(initScene.iniciou == 0)
        // {
        //     StartCoroutine (PausarStart());
        //     director.Play();
        // }

        // else
        // {
        //     director.Stop();
        // }

        // if(initScene.iniciou == 1)
        // {
        //     director.Play();
        // }

        if(PlayerPrefs.GetInt("iniciou") == 1)
        {
            StartCoroutine (Pausar());
        }

    }

    // void Awake()
    // {
    //     // if(director == null)
    //     // {
    //     //     player.andar = true;
    //     // }
    // }

    private IEnumerator Pausar()
    {
        yield return new WaitForSeconds (4);
        // director.Stop();
        // player.gameObject.SetActive(false);
        // reload.gameObject.SetActive(true);
        player.andar = true;
    }

    private IEnumerator PausarStart()
    {
        yield return new WaitForSeconds (15);
    }
}