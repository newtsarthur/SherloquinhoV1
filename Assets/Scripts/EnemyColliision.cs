using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliision : MonoBehaviour
{
    public Transform player;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(target != null){
            speed = 0f;
            Vector3 direction = player.position - transform.position;
            // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movement = direction;
            
        }
        else
        {
            speed = 0f;
            Vector3 direction = player.position - transform.position;
            // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate(){
        moveCharacterd(movement);
    }

    void moveCharacterd(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }


    // public float speed;
    private Transform target;

    // private void Update() {
    //     if(target != null){
    //         float step = speed * Time.deltaTime;
    //         transform.position = Vector2.MoveTowards(transform.position, target.position, step);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            target = other.transform;
        }
            
            Debug.Log(target);
    }   
    private void OnTriggerExit2D(Collider2D other) {
         if(other.gameObject.tag == "Player") {
            target = null;
        }
    }
}
