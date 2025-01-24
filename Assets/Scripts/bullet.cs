using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public player player;
    public Rigidbody2D rb;
    private CapsuleCollider2D col;


    void Start()
    {
        player = FindObjectOfType<player>();
        col = GetComponent<CapsuleCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // if(collision.gameObject.CompareTag("Bullet_Fire")|| collision.gameObject.CompareTag("Bullet_Blue") || collision.gameObject.CompareTag("Bullet_Enemy"))
        // {
        //     col.enabled = false;
        //     StartCoroutine (AtBullet());
            
        // }
        // if(col.enabled == true)
        // {
        //     GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //     Destroy(effect, 0.5f);
        //     Destroy(gameObject, 2);

        //     Collider2D[]playerToDamage = Physics2D.OverlapCircleAll(rb.position,attackRange, whatsIsPlayer);
        //     for (int i = 0; i < playerToDamage.Length; i++) 
        //     {
        //         playerToDamage[i].GetComponent<player>().TakeDamage(EnemyDamage.DamagedGhost);
        //         player.EffectsSong.Bonk();
        //         Destroy(gameObject);
        //     }
        // }
        if(col.enabled == true)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.5f);
            // Destroy(gameObject);
            Destroy(gameObject, 2);

            Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(rb.position, player.attackRange, player.whatsIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++) {
                enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(player.damage);
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
    //     if(collision.gameObject.CompareTag("Bullet_Enemy") || collision.gameObject.CompareTag("Bullet_Fire") || collision.gameObject.CompareTag("Bullet_Blue"))
    //     {
    //         col.enabled = false;
    //         if(player.hitDirection == 0)
    //         {
    //             // player.rb.AddForce(player.firepoint.right * 2, ForceMode2D.Impulse);
    //             rb.AddForce(player.firepointDown.up *- 0.3f, ForceMode2D.Impulse);
    //         }
    //         if(player.hitDirection == 1)
    //         {
    //             rb.AddForce(player.firepointTop.up * 0.3f, ForceMode2D.Impulse);
    //         }
    //         if(player.hitDirection == 2)
    //         {
    //             rb.AddForce(player.firepoint.right * 0.3f, ForceMode2D.Impulse);  
    //         }
    //         if(player.hitDirection == 3)
    //         {
    //             rb.AddForce(player.firepointLeft.right *- 0.3f, ForceMode2D.Impulse);
    //         }
    //         StartCoroutine (AtBullet());
    //     }
    //     if(col.enabled == true)
    //     {
    //         GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //         Destroy(effect, 1.5f);
    //         Destroy(gameObject);

    //         Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(rb.position, player.attackRange, player.whatsIsEnemies);
    //         for (int i = 0; i < enemiesToDamage.Length; i++) {
    //             enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(player.damage);
    //             player.EffectsSong.Bonk();
    //         }
    //     }

    // }
    private IEnumerator AtBullet()
    {
        yield return new WaitForSeconds (0.01f);
        col.enabled = true;
    }
}
