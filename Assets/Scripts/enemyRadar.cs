using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRadar : MonoBehaviour
{
    public CircleCollider2D col;
    public GameObject otherT;
    public Transform target;
    private Rigidbody2D rb;
    public bool clonado;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        clonado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null){
            clonado = true;
        }
        else
        {
            clonado = false;
        }
        // Debug.Log(clonado);

    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            target = other.transform;
        }
            
    }   
    private void OnTriggerExit2D(Collider2D other) {
         if(other.gameObject.tag == "Player") {
            target = null;
        }
    }
}
