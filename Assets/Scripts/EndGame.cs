using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update

    public int mobsKilleds;
    public int lifesU;

    public PlayableDirector director;
    // public GameObject player;
    player player;

    public GameObject spawner;
    public GameObject enemy;
    public GameObject bottom;
    public GameObject reload;
    EffectsSong EffectsSong;


    public void Start()
    {
        // mobsKilleds = 15;
        player = FindObjectOfType<player>();
        EffectsSong = FindObjectOfType<EffectsSong>();


    }
    
    public void Update()
    {
        // if(mobsKilleds != 0)
        // {
        //     Debug.Log(mobsKilleds);
        // }
        if(mobsKilleds == 10)
        {
            player.speed = 0.85f;
            // player.life = 4;
            EffectsSong.levelUp();

        }
        if(mobsKilleds >= 30)
        {
            director.Play();
            // Destroy(spawner.gameObject);
            // .SetActive(false);
            // Destroy(enemy.gameObject);

            // enemy.gameObject.SetActive(false);
            StartCoroutine (Pausar());
            bottom.gameObject.SetActive(false);
        }
    } 

    private IEnumerator Pausar()
    {
        yield return new WaitForSeconds (30);
        director.Stop();
        player.gameObject.SetActive(false);
        reload.gameObject.SetActive(true);
    }
    // void Awake()
    // {

    // }
}
