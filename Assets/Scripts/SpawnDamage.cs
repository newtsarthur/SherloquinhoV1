using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDamage : MonoBehaviour
{
    private UnityEngine.Object enemyRef;

    public float attackRange;
    public Transform attackPos;
    public float Attack;
    public int DamagedGhost;
    public LayerMask whatsIsPlayer;
    public int health;

    public GameObject bloodEffect;
    public GameObject bodyEnemy;

    // public enemyIA enemyIA;

    void Start()
    
    {
        Attack = 0;
    }
    void Update()
    {
        Collider2D[]playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatsIsPlayer);
        if(Attack <= 0)
        {
            for (int i = 0; i < playerToDamage.Length; i++) 
            {
                playerToDamage[i].GetComponent<player>().TakeDamage(DamagedGhost);
                Debug.Log("macetado");
                Attack = 1;
            }
        }else{
            Attack -= Time.deltaTime;
        }

        // if(health <= 0)
        // {
        // }
        OnEnemyDied();

    }
    // public void TakeDamage(int damage)
    // {
    //     // animator.SetBool("ghostDamaged", true);
    //     health -= damage;
    //     Instantiate(bloodEffect, transform.position, Quaternion.identity);
    //     // enemyIA.lenti();
    //     Debug.Log("levou dano");
    //     // StartCoroutine(lenti());

    // }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    // public IEnumerator lenti()
    // {
    //     enemyIA.rap = true;
    //     enemyIA.speed = 0.05f;
    //     yield return new WaitForSeconds (2f);
    //     enemyIA.rap = false;
    //     // enemyIA.speed = 0.4f;
    // }

    private void OnEnemyDied()
    {
        // animator.SetBool("deadGhost", true);
        // dropScript.Drop();
        // Instantiate(bloodEffect, transform.position, Quaternion.identity);
        // Instantiate(bloodEffect, transform.position, Quaternion.identity);
        if(health == 0)
        {
            Destroy(bodyEnemy.gameObject);
        }
    }
}
