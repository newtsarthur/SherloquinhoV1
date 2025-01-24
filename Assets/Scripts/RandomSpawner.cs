using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public enemyRadar enemyRadar;
    private float cont = 4f;
    private float clone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(enemyRadar.clonado);
        if(clone == 30)
        {
            enemyRadar.gameObject.SetActive(false);
        }
        if(enemyRadar.clonado == false) return;
        if(clone == 30) return;
        if(enemyRadar.clonado == true);
        {
            cont -= Time.deltaTime;
            if(cont <= 0)
            {
                if(enemyRadar.clonado == false) return;
                StartCoroutine(TempoSpawner());
                cont = 4f;
            }
            // Debug.Log(cont);

        }
        if(enemyRadar.clonado == false)
        {
            cont = 4f;
        }
    }

    private IEnumerator TempoSpawner()
    {
        yield return new WaitForSeconds (0.5f);
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        
        // int randSpawPoint = 0;

        // Randomizar:
        int randSpawPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawPoint].position, transform.rotation);
        // if(randEnemy == enemyPrefabs.gameObject.tag == "spawner")
        // {
        //     gameObject.SetActive(false);
        //     Destroy(this.gameObject);
        // }

        // Debug.Log(clone += 1);
        clone += 1;
    }

}
