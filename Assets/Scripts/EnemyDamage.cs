using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private UnityEngine.Object enemyRef;
    public dropItems dropScript;

    public float attackRange;
    public Transform attackPos;
    public float Attack;
    public int DamagedGhost;
    public LayerMask whatsIsPlayer;
    public int health;

    public GameObject bloodEffect;
    public GameObject bodyEnemy;
    private int mobsMortos = 1;

    public EndGame EndGame;
    public game_controler game_controler;

    public enemyIA enemyIA;
    player player;

    private CircleCollider2D col;

    public GameObject[] bar;

    // EndGame EndGame;


    void Start()
    {
        dropScript = GetComponent<dropItems>();
        Attack = 0;
        player = FindObjectOfType<player>();
        col = GetComponent<CircleCollider2D>();
        // EndGame = FindObjectOfType<EndGame>();

    }

    void Awake()
    {
        EndGame = FindObjectOfType<EndGame>();
        game_controler = FindObjectOfType<game_controler>();
        // col.isTrigger = false;
    }

    void Update()
    {
        if(enemyIA.green == true)
        {
            if(health == 3)
            {
                bar[0].gameObject.SetActive(true);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
            }
            if(health == 2)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(true);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
            }
            if(health == 1)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(true);
                bar[3].gameObject.SetActive(false);
            }
            if(health == 0)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(true);
            }
        }
        if(enemyIA.red == true)
        {
            if(health == 6)
            {
                bar[0].gameObject.SetActive(true);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
            }
            if(health == 5)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(true);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
            }
            if(health == 4)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(true);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
            }
            if(health == 3)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(true);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
            }
            if(health == 2)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(true);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
            }
            if(health == 1)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(true);
                bar[6].gameObject.SetActive(false);
            }
            if(health == 0)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(true);
            }
        }
        if(enemyIA.blue == true)
        {
            if(health == 9)
            {
                bar[0].gameObject.SetActive(true);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
                bar[7].gameObject.SetActive(false);
                bar[8].gameObject.SetActive(false);
                bar[9].gameObject.SetActive(false);
            }
            if(health == 8)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(true);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
                bar[7].gameObject.SetActive(false);
                bar[8].gameObject.SetActive(false);
                bar[9].gameObject.SetActive(false);
            }
            if(health == 7)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(true);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
                bar[7].gameObject.SetActive(false);
                bar[8].gameObject.SetActive(false);
                bar[9].gameObject.SetActive(false);
            }
            if(health == 6)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(true);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
                bar[7].gameObject.SetActive(false);
                bar[8].gameObject.SetActive(false);
                bar[9].gameObject.SetActive(false);
            }
            if(health == 5)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(true);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
                bar[7].gameObject.SetActive(false);
                bar[8].gameObject.SetActive(false);
                bar[9].gameObject.SetActive(false);
            }
            if(health == 4)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(true);
                bar[6].gameObject.SetActive(false);
                bar[7].gameObject.SetActive(false);
                bar[8].gameObject.SetActive(false);
                bar[9].gameObject.SetActive(false);
            }
            if(health == 3)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(true);
                bar[7].gameObject.SetActive(false);
                bar[8].gameObject.SetActive(false);
                bar[9].gameObject.SetActive(false);
            }
            if(health == 2)
            {
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
                bar[7].gameObject.SetActive(true);
                bar[8].gameObject.SetActive(false);
                bar[9].gameObject.SetActive(false);
                
            }
            if(health == 1)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
                bar[7].gameObject.SetActive(false);
                bar[8].gameObject.SetActive(true);
                bar[9].gameObject.SetActive(false);
            }
            if(health == 0)
            {
                bar[0].gameObject.SetActive(false);
                bar[1].gameObject.SetActive(false);
                bar[2].gameObject.SetActive(false);
                bar[3].gameObject.SetActive(false);
                bar[4].gameObject.SetActive(false);
                bar[5].gameObject.SetActive(false);
                bar[6].gameObject.SetActive(false);
                bar[7].gameObject.SetActive(false);
                bar[8].gameObject.SetActive(false);
                bar[9].gameObject.SetActive(true);
            }
        }
        Collider2D[]playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatsIsPlayer);
        if(Attack <= 0)
        {
            for (int i = 0; i < playerToDamage.Length; i++) 
            {
                playerToDamage[i].GetComponent<player>().TakeDamage(DamagedGhost);
                // Debug.Log("macetado");
                Attack = 1;
            }
        }else{
            Attack -= Time.deltaTime;
        }
        if(player.life == 1)
        {
            enemyIA.speed = 0.6f;
        }

        if(EndGame.mobsKilleds >= 30)
        {
            enemyIA.speed = 0f;
            // gameObject.destroy.this(enemyIA);
        }

        // if(health <= 0)
        // {
        // }
        OnEnemyDied();

    }
    public void TakeDamage(int damage)
    {
        // animator.SetBool("ghostDamaged", true);
        health -= damage;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        // enemyIA.lenti();
        // Debug.Log("levou dano");
        StartCoroutine(lenti());

    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public IEnumerator lenti()
    {
        enemyIA.rap = true;
        enemyIA.speed = 0.1f;
        yield return new WaitForSeconds (1f);
        enemyIA.rap = false;
        // enemyIA.speed = 0.4f;
    }

    private void OnEnemyDied()
    {
        // animator.SetBool("deadGhost", true);
        // dropScript.Drop();
        // Instantiate(bloodEffect, transform.position, Quaternion.identity);
        // Instantiate(bloodEffect, transform.position, Quaternion.identity);
        if(health <= 0)
        {
            EndGame.mobsKilleds += mobsMortos;
            game_controler.gameController.SetKills(EndGame.mobsKilleds);
            // PlayerPrefs.SetInt("mobsKilleds", mobsMortos);
            // Debug.Log(PlayerPrefs.GetInt("mobsKilleds"));
            dropScript.Drop();
            // Instantiate(bloodEffect, transform.position, Quaternion.identity);
            // Instantiate(bloodEffect, transform.position, Quaternion.identity);
            Destroy(bodyEnemy.gameObject);
        }
    }
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.CompareTag("Bullet"))
    //     {
    //         col.isTrigger = false;
    //         // StartCoroutine (AtravessarEnemy());
    //     }
    // }
    // private IEnumerator AtravessarEnemy()
    // {
    //     yield return new WaitForSeconds (1f);
    //     col.isTrigger = true;
    // }
}
