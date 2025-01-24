using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeWeapon : triggerDamage, weapons
{
    [SerializeField]
    private float attackTime = 0.83f;

    public bool IsAttacking { get; private set; }

    private void Awake()
    {
        IsAttacking = false;
    }

    // void OnTriggerEnter2D(Collider2D collider)
    // {
    //     if(collider.gameObject.CompareTag("inimigo"))
    //     {
    //         life -= 0;
    //     }
    // }

    public void Attack()
    {
        if (!IsAttacking)
        {
            gameObject.SetActive(true);
            IsAttacking = true;
            StartCoroutine(PerformAttack());
        }

    }

    private IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(attackTime);
        gameObject.SetActive(false);
        IsAttacking = false;
    }
}
