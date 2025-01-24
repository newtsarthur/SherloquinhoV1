using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class initScene : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayableDirector director;
    public int iniciou = 0;
    public sceneStart sceneStart;
    public player player;



    void Start()
    {
        sceneStart = FindObjectOfType<sceneStart>();
        player = FindObjectOfType<player>();


        if(PlayerPrefs.GetInt("iniciou") == 0)
        {
            director.Play();
            StartCoroutine (PausarStart());
            // StartCoroutine (Pausar());

        }
        if(PlayerPrefs.GetInt("iniciou") != 0)
        {
            // PlayerPrefs.SetInt("iniciou", 1);
            director.Stop();
            sceneStart.director.Play();
        }

        if(player.life <= 0)
        {
            director.Stop();
        }
    }
    // void Awake()
    // {
    //     Skip();
    // }
    void Update() {
        if(iniciou == 1)
        {
            director.Stop();
        }
    }
    // Update is called once per frame
    // void Update()
    // {
    //     // Debug.Log(PlayerPrefs.GetInt("iniciou"));
    // }
    // public void Update()
    // {
    //     Debug.Log(iniciou);
    // }
    
    private IEnumerator Pausar()
    {
        yield return new WaitForSeconds (1);
        // director.Stop();
        // player.gameObject.SetActive(false);
        // reload.gameObject.SetActive(true);
        player.andar = true;
    }

    private IEnumerator PausarStart()
    {
        yield return new WaitForSeconds (15);
        // iniciou += 1;
        PlayerPrefs.SetInt("iniciou", 1);
        sceneStart.director.Play();
        // yield return new WaitForSeconds (4);
        // player.andar = true;
    }
    public void Skip()
    {
        iniciou = 1;
        Debug.Log(iniciou);
    }
}
