using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawArv : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spawnsPrefabs;
    // public enemyRadar enemyRadar;
    private float cont = 1f;
    private float clone;
    private bool spawners;

    // Start is called before the first frame update
    void Start()
    {
        clone = 0;
        spawners = true;

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(enemyRadar.clonado);
        // if(enemyRadar.clonado == false) return;
        if(clone >= 10) return;
        if(spawners);
        {
            cont -= Time.deltaTime;
            if(cont <= 0)
            {
                // if(enemyRadar.clonado == false) return;
                StartCoroutine(TempoSpawner());
                cont = 0.05f;
            }
            // Debug.Log(cont);

        }
        if(!spawners)
        {
            cont = 1f;
        }
    }

    private IEnumerator TempoSpawner()
    {
        yield return new WaitForSeconds (0.5f);
        int randEnemy = Random.Range(0, spawnsPrefabs.Length);
        int randSpawPoint = Random.Range(0, spawnPoints.Length);
        int i = randSpawPoint;
        // Instantiate(spawnsPrefabs[randEnemy], spawnPoints[randSpawPoint].position, transform.rotation);
        // if(clone == 0 && randSpawPoint == i)
        // {
        //     randSpawPoint = Random.Range(0, spawnPoints.Length);
        //     if(randSpawPoint != i){
        //         // i = randSpawPoint;
        //         Instantiate(spawnsPrefabs[randEnemy], spawnPoints[randSpawPoint].position, transform.rotation);
        //         clone += 1;
        //     }

        //     // if(clone == 0 && randSpawPoint != i){
        //     //     // i = randSpawPoint;
        //     // }
        //     // else
        //     // {
        //     //     randSpawPoint = Random.Range(0, spawnPoints.Length);
        //     // }
        //     // Debug.Log(clone += 1);
        //     // int help = randSpawPoint -= i;
        //     // int i = randSpawPoint;
        //     // i += 1;
        //     // clone += 1;

        // }
        if(randSpawPoint == i)
        {
            randSpawPoint = Random.Range(0, spawnPoints.Length);
            
            if(randSpawPoint != i){
                Instantiate(spawnsPrefabs[randEnemy], spawnPoints[randSpawPoint].position, transform.rotation);
                clone += 1;
            }
        }
        // Debug.Log(clone += 1);
        // randSpawPoint = Random.Range(0, spawnPoints.Length);

        // Debug.Log(randSpawPoint);
        
        // int randSpawPoint = 0;

        // Randomizar:
        // int help;

        // if(clone == 0)
        // {
        //     Instantiate(spawnsPrefabs[randEnemy], spawnPoints[randSpawPoint].position, transform.rotation);
        //     Debug.Log(clone += 1);
        //     // int help = randSpawPoint -= i;
        // }
        // if(clone != 0 && randSpawPoint == 8)
        // {
        //     Instantiate(spawnsPrefabs[randEnemy], spawnPoints[8].position, transform.rotation);
        //     Debug.Log(clone += 1);
        // }
        // if(clone != 0 && randSpawPoint == 7 &&)
        // {
        //     Instantiate(spawnsPrefabs[randEnemy], spawnPoints[7].position, transform.rotation);
        //     Debug.Log(clone += 1);
        // }
        // if(clone != 0 && randSpawPoint == 6)
        // {
        //     Instantiate(spawnsPrefabs[randEnemy], spawnPoints[6].position, transform.rotation);
        //     Debug.Log(clone += 1);
        // }
        // if(clone != 0 && randSpawPoint == 5)
        // {
        //     Instantiate(spawnsPrefabs[randEnemy], spawnPoints[5].position, transform.rotation);
        //     Debug.Log(clone += 1);
        // }
        // if(clone != 0 && randSpawPoint == 4)
        // {
        //     Instantiate(spawnsPrefabs[randEnemy], spawnPoints[4].position, transform.rotation);
        //     Debug.Log(clone += 1);
        // }
        // if(clone != 0 && randSpawPoint == 3)
        // {
        //     Instantiate(spawnsPrefabs[randEnemy], spawnPoints[3].position, transform.rotation);
        //     Debug.Log(clone += 1);
        // }
        // if(clone != 0 && randSpawPoint == 2)
        // {
        //     Instantiate(spawnsPrefabs[randEnemy], spawnPoints[2].position, transform.rotation);
        //     Debug.Log(clone += 1);
        // }
        // if(clone != 0 && randSpawPoint == 1)
        // {
        //     Instantiate(spawnsPrefabs[randEnemy], spawnPoints[1].position, transform.rotation);
        //     Debug.Log(clone += 1);
        // }
        // if(clone != 0 && randSpawPoint == 0)
        // {
        //     Instantiate(spawnsPrefabs[randEnemy], spawnPoints[0].position, transform.rotation);
        //     Debug.Log(clone += 1);
        // }
        // Debug.Log(randSpawPoint);





        // public List<GameObject> locais;
        // public List<GameObject> enemy;

        // private float cronometro;
        // public float tempo;

        // void Update () {
        // cronometro += Time.deltaTime;
        // if (cronometro >= Random.Range(tempo, 8f)){
        //     cronometro = 0;
        //     int tempEnemyRange = Random.Range (0,enemy.Length);
        //     int tempLocalsRange = Random.Range(0, locais.Length);

        //     Instantiate (enemy[tempEnemyRange], locais[tempLocalRange].transform.position, locais[tempLocalsRange].transform.rotation);

        //     enemy.RemoveAt(tempEnemyRange);
        //     locais.RemoveAt(tempLocalRange);
        // }
    }

    // private void OnTriggerStay2D(Collider2D other) {
    //     if(other.gameObject.tag == "spawner") {
    //             gameObject.SetActive(false);
    //             Destroy(this.gameObject);
    //     }
    // }
}
