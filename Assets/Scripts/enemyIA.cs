using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyIA : MonoBehaviour
{
    public Transform player;
    public player player2;

    public float speed;
    public Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 movementB;
    public CircleCollider2D col;
    public CapsuleCollider2D colW;

    public GameObject otherT;
    private Transform target;
    public bool rap;
    EndGame EndGame;

    public GameObject[] guns;

    public float bulletForce = 0.9f;

    private float maxTimeAttack = 0.95f;
    private float nextAttack = 0f;

    // public Transform firepointTop;
    // public Transform firepointDown;
    public Transform firepoint;
    public GameObject bulletPrefab;
    public bool green;
    public bool red;
    public bool blue;

    public TriggerCollision_Left TriggerCollision_Left;
    public TriggerCollision_Right TriggerCollision_Right;
    public TriggerCollision TriggerCollision;
    public TriggerCollsion_Down TriggerCollsion_Down;

    public int colDirection = 1;
    
    [Header("Animações do Enemy:")]
    public Animator anim;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        colW = colW.GetComponent<CapsuleCollider2D>();
        rap = false;
        EndGame = FindObjectOfType<EndGame>();

        player2 = FindObjectOfType<player>();

        TriggerCollision_Left = FindObjectOfType<TriggerCollision_Left>();
        TriggerCollision_Right = FindObjectOfType<TriggerCollision_Right>();
        TriggerCollision = FindObjectOfType<TriggerCollision>();
        TriggerCollsion_Down = FindObjectOfType<TriggerCollsion_Down>();




    }
    // void Awake()
    // {
    //     // colW = colW.GetComponent<CircleCollider2D>();
    //     colW.isTrigger = false;
    // }

    void Update(){

        if(target != null){
            if(rap == false)
            {
                speed = 0.15f;
 
            }
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            movement = direction;
            shot();
        }

        if(EndGame.mobsKilleds >= 30)
        {
            Destroy(this.gameObject, 1);
        }

        // if(health <= 0)
        // {
        //     OnEnemyDied();
        // }
    }

    private void FixedUpdate(){
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }


    // public float speed;

    // private void Update() {
    //     if(target != null){
    //         float step = speed * Time.deltaTime;
    //         transform.position = Vector2.MoveTowards(transform.position, target.position, step);
    //     }
    // }

    // void OnTriggerEnter2D(Collider2D collider)
    // {
    //     if(colTrigge.gameObject.CompareTag("Player"))
            
    //     {
    // }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            target = other.transform;

            TriggerCollision_Left.gameObject.SetActive(true);
            TriggerCollision_Right.gameObject.SetActive(true);
            TriggerCollision.gameObject.SetActive(true);
            TriggerCollsion_Down.gameObject.SetActive(true);
            if(blue)
            {
                anim.SetBool("Blue", true);
                if(colDirection == 0)
                {
                    anim.SetFloat("Horizontal", 0);
                    anim.SetFloat("Vertical", 1);
                }
                if(colDirection == 1)
                {
                    anim.SetFloat("Horizontal", 0);
                    anim.SetFloat("Vertical", -1);
                }
                if(colDirection == 2)
                {
                    anim.SetFloat("Horizontal", 1);
                    anim.SetFloat("Vertical", 0);
                }
                if(colDirection == 3)
                {
                    anim.SetFloat("Horizontal", -1);
                    anim.SetFloat("Vertical", 0);
                }
            }
            if(green)
            {
                anim.SetBool("Green", true);
                if(colDirection == 0)
                {
                    anim.SetFloat("Horizontal", 0);
                    anim.SetFloat("Vertical", 1);
                }
                if(colDirection == 1)
                {
                    anim.SetFloat("Horizontal", 0);
                    anim.SetFloat("Vertical", -1);
                }
                if(colDirection == 2)
                {
                    anim.SetFloat("Horizontal", 1);
                    anim.SetFloat("Vertical", 0);
                }
                if(colDirection == 3)
                {
                    anim.SetFloat("Horizontal", -1);
                    anim.SetFloat("Vertical", 0);
                }
            }
            if(red)
            {
                anim.SetBool("Red", true);
                if(colDirection == 0)
                {
                    anim.SetFloat("Horizontal", 0);
                    anim.SetFloat("Vertical", 1);
                }
                if(colDirection == 1)
                {
                    anim.SetFloat("Horizontal", 0);
                    anim.SetFloat("Vertical", -1);
                }
                if(colDirection == 2)
                {
                    anim.SetFloat("Horizontal", 1);
                    anim.SetFloat("Vertical", 0);
                }
                if(colDirection == 3)
                {
                    anim.SetFloat("Horizontal", -1);
                    anim.SetFloat("Vertical", 0);
                }
            }
        }
            
            // Debug.Log(target);
    }   

    private void OnTriggerExit2D(Collider2D other) {
         if(other.gameObject.tag == "Player") {
            colW.isTrigger = false;
            target = null;
            speed = 0f;
            colDirection = 4;
            anim.SetBool("Blue", false);
            anim.SetBool("Green", false);
            anim.SetBool("Red", false);
            TriggerCollision_Left.gameObject.SetActive(false);
            TriggerCollision_Right.gameObject.SetActive(false);
            TriggerCollision.gameObject.SetActive(false);
            TriggerCollsion_Down.gameObject.SetActive(false);

        }
    }

    private void shot(){
        if(Time.time >= nextAttack)
        {
            //Inimigo verde
            if(green)
            {
                GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
                colW.isTrigger = true;
                Destroy(bullet.gameObject, 5f);
                nextAttack = Time.time + 1f / maxTimeAttack;

            }
            //Inimigo azul
            if(blue)
            {
                GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
                colW.isTrigger = true;
                // Destroy(bullet.gameObject, 10f);
                nextAttack = Time.time + 0.5f / maxTimeAttack;
            }
            //Inimigo vermelho
            if(red)
            {
                GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
                colW.isTrigger = true;
                Destroy(bullet.gameObject, 5f);
                nextAttack = Time.time + 0.7f / maxTimeAttack;
            }
        }
    }
}
