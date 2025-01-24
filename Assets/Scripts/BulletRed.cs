using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRed : MonoBehaviour
{
    public GameObject hitEffect;
    public player player;

    public float attackRange;

    public Rigidbody2D rb;

    private CapsuleCollider2D col;

    public Transform attackPos;

    public LayerMask whatsIsPlayer;
    public enemyIA enemyIA;
    public EnemyDamage EnemyDamage;

    public float force;

    void Start()
    {

        player = GameObject.FindObjectOfType<player>();
        EnemyDamage = FindObjectOfType<EnemyDamage>();
        col = GetComponent<CapsuleCollider2D>();
        Dir();

        enemyIA = FindObjectOfType<enemyIA>();

    }
    public void Dir() 
    {
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    // void Awake() {
    //     StartCoroutine (AtravessarEnemy());
    // }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            col.enabled = false;
            // Dir();
            StartCoroutine (AtBullet());
            
        }
        if(col.enabled == true)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject, 2);

            Collider2D[]playerToDamage = Physics2D.OverlapCircleAll(rb.position,attackRange, whatsIsPlayer);
            for (int i = 0; i < playerToDamage.Length; i++) 
            {
                playerToDamage[i].GetComponent<player>().TakeDamage(EnemyDamage.DamagedGhost);
                player.EffectsSong.Bonk();
                Destroy(gameObject);
            }
            if(collision.gameObject.CompareTag("Colisor"))
            {
                Destroy(gameObject);
            }
        }
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("spawner") || collision.gameObject.CompareTag("Bullet_Enemy") )
    //     {
    //         col.enabled = false;
    //         Dir();
    //         StartCoroutine (AtBullet());
    //     }
    //     if(col.enabled == true)
    //     {
    //         GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //         Destroy(effect, 0.5f);
    //         Destroy(gameObject);

    //         Collider2D[]playerToDamage = Physics2D.OverlapCircleAll(rb.position,attackRange, whatsIsPlayer);
    //         for (int i = 0; i < playerToDamage.Length; i++) 
    //         {
    //             playerToDamage[i].GetComponent<player>().TakeDamage(EnemyDamage.DamagedGhost);
    //             player.EffectsSong.Bonk();
    //         }
    //     }
    // }
    // private IEnumerator AtravessarEnemy()
    // {
    //     yield return new WaitForSeconds (0.2f);
    //     col.isTrigger = false;
    // }
    private IEnumerator AtBullet()
    {
        yield return new WaitForSeconds (0.01f);
        col.enabled = true;
    }
}
