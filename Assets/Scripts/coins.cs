using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    // [SerializeField] private LayerMask layerGround;
    private Rigidbody2D itemCoins;
    private BoxCollider2D col;
    public player player;
    public int ganharLife;

    EndGame EndGame;

    EffectsSong EffectsSong;


    void Start()
    {
        EndGame = FindObjectOfType<EndGame>();
        EffectsSong = FindObjectOfType<EffectsSong>();

    }
    
    void Update()
    {
        if(EndGame.mobsKilleds >= 30)
        {
            Destroy(this.gameObject, 1);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<player>();
        col = GetComponent<BoxCollider2D>();
        col.isTrigger = false;
        itemCoins = GetComponent<Rigidbody2D>();
    }

    // Adicionar moeda ao jogador
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            EffectsSong.addLife();
            col.enabled = false;
            player.life += ganharLife;
            Destroy(this.gameObject);
        }
    }
    
    // // Colisor com o chão
    // private bool isGrounded()
    // {
    //     RaycastHit2D ground = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, Vector2.down, 0.1f, layerGround);

    //     return ground.collider != null;
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(itemCoins);
            col.isTrigger = true;
        }
    }
}
