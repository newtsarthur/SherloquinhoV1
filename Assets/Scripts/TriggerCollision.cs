using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollision : MonoBehaviour
{
    public PolygonCollider2D colTrigge;
    public enemyIA enemyIA;

    void Start()
    {
        enemyIA = FindObjectOfType<enemyIA>();
        colTrigge = colTrigge.GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag == "Player") {
            enemyIA.colDirection = 0;
        }
    }
}
