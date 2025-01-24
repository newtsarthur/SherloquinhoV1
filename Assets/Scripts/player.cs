// Copyright 2022 Newtsarthur - Todos os direitos reservados.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class player : MonoBehaviour
{
    [Header("Armas")]
    [SerializeField] GameObject weaponObject;
    [SerializeField] weapons weapon;
    public GameObject[] guns;
    public GameObject[] guns_Light;


    public Transform firepointTop;
    public Transform firepointDown;
    public Transform firepoint;
    public Transform firepointLeft;
    public GameObject bulletPrefab;
    public GameObject bulletLeftPrefab;
    public GameObject bulletTopPrefab;
    public GameObject bulletDownPrefab;

    public float bulletForce = 0.85f;

    private int auxDirecaoLeft;
    private int auxDirecaoRight;
    private int auyDirecaoTop;
    private int auyDirecaoDown;

    [Header("Lanterna Controlls")]
    public GameObject lanternOn;
    private int lantDir = 4;
    public GameObject lanternOff;
    

    [Header("Tela de pause")]
    public GameObject pause;
    public GameObject credito;
    public GameObject doar;

    [Header("Tempo da força utilizada:")]
    private float maxTimeAttack = 0.95f;
    private float nextAttack = 0f;

    [Header("LayerMask inimigos")]
    public LayerMask whatsIsEnemies;
    public LayerMask whatsIsSpawns;

    [Header("Tamanho do ataque")]
    public float attackRange;

    [Header("Valor do dano")]
    public int damage;

    [Header("Direções do ataque")]
    public Transform attackPos;
    public Transform attackLeftPos;
    public Transform attackTopPos;
    public Transform attackDownPos;

    [Header("Cenas")]
    public PlayableDirector director;
    private bool cena;
    public initScene initScene;
    public int jacomecou;
    public int ini;

    [Header("Enemy")]
    public GameObject direco;
    public enemyIA enemyIA;
    public enemyRadar enemyRadar;

    private bool dano;
    private float contador;

    [Header("Salvar dados do personagem:")]
    SavePlayer playerPosData;
    private Vector3 respawnPoint;

    public Vector2 laspos;

    public bool salvado;

    public game_controler coinsOn;

    [Header("Particle system:")]
    public ParticleSystem effectkAttackLeft;
    public ParticleSystem effectkAttackRight;
    public ParticleSystem effectkAttackTop;
    public ParticleSystem effectkAttackDown;
    public GameObject bloodEffect;
    public GameObject danger;

    [Header("Vida do personagem:")]
    public GameObject[] hearts;
    public GameObject[] heartsBlackAdicional;
    public int life = 3;

    [Header("Física do personagem")]
    public Rigidbody2D rb;
    private CapsuleCollider2D col;

    [Header("Animações do player:")]
    public Animator anim;
    public Animator gun;
    public GameObject CenaDeTeleporte;
    public GameObject Cameras;
    public GameObject Canvas;
    public int hitDirection;

    [Header("Velocidade do player:")]
    public float speed = 0.55f;

    [Header("Movimentação do player:")]
    private int auxDirecao;
    private int auyDirecao;
    public FixedJoystick moveJoystick;

    private bool click;

    public static bool andar;
    EndGame EndGame;
    Songs Songs;
    public EffectsSong EffectsSong;

    void Start()
    {
        click = false;
        anim = GetComponent<Animator>();
        gun = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        coinsOn = FindObjectOfType<game_controler>();
        initScene = FindObjectOfType<initScene>();

        Songs = FindObjectOfType<Songs>();
        EffectsSong = FindObjectOfType<EffectsSong>();

        anim.SetBool("LeftIdle", false);
        anim.SetBool("RightIdle", false);
        anim.SetBool("TopIdle", false);
        anim.SetBool("DownIdle", true);
        hitDirection = 0;

        if(PlayerPrefs.GetInt("iniciou") == 0)
        {
            StartCoroutine (Pausar());
            ini += 1;
        }
        if (weaponObject != null)
        {
            weapon = weaponObject.GetComponent<weapons>();
        }
        EndGame = FindObjectOfType<EndGame>();
        lanternOff.gameObject.SetActive(false);
    }

    private IEnumerator Pausar()
    {
        yield return new WaitForSeconds (19);
        andar = true;
    }

    void Update()
    {   
        // ShotSetas();
        if(EndGame.mobsKilleds <= 9)
        {
            if(life >= 3)
            {
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(true);
                hearts[3].gameObject.SetActive(false);
                life = 3;
            }
            if(life == 2){
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(false);
                hearts[3].gameObject.SetActive(false);
            }
            if(life == 1){
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(false);
                hearts[2].gameObject.SetActive(false);
                hearts[3].gameObject.SetActive(false);
            }
            if(life <= 0){
                hearts[0].gameObject.SetActive(false);
                hearts[1].gameObject.SetActive(false);
                hearts[2].gameObject.SetActive(false);
                hearts[3].gameObject.SetActive(false);
                
                andar = false;
                PlayerPrefs.SetInt("iniciou", 1);
            }
        }
        if(EndGame.mobsKilleds >= 10)
        {
            heartsBlackAdicional[0].gameObject.SetActive(true);

            if(life >= 4){
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(true);
                hearts[3].gameObject.SetActive(true);
                life = 4;
            }
            if(life == 3)
            {
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(true);
                hearts[3].gameObject.SetActive(false);
            }
            if(life == 2){
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(true);
                hearts[2].gameObject.SetActive(false);
                hearts[3].gameObject.SetActive(false);
            }
            if(life == 1){
                hearts[0].gameObject.SetActive(true);
                hearts[1].gameObject.SetActive(false);
                hearts[2].gameObject.SetActive(false);
                hearts[3].gameObject.SetActive(false);
            }
            if(life <= 0){
                hearts[0].gameObject.SetActive(false);
                hearts[1].gameObject.SetActive(false);
                hearts[2].gameObject.SetActive(false);
                hearts[3].gameObject.SetActive(false);
                
                andar = false;
                PlayerPrefs.SetInt("iniciou", 1);
            }
        }

        if(andar)
        {
            MoveTouch();
            // Debug.Log(moveJoystick.Horizontal);
            // Debug.Log(moveJoystick.Vertical);
            Power();
            if(life == 1)
            {
                speed = 0.6f;
                danger.gameObject.SetActive(true);
            }
            if(life >= 2)
            {
                speed = 0.55f;
                danger.gameObject.SetActive(false);
            }
        }

        if(life == 1 && EndGame.mobsKilleds >= 15)
        {
            danger.gameObject.SetActive(false);
        }

        playerPosData.PlayerPosSave();

        PlayerPrefs.SetInt("iniciou", ini);
        PlayerPrefs.SetInt("iniciou", ini);
    }
    void Awake()
    {
        col = GetComponent<CapsuleCollider2D>();
        director = GetComponent<PlayableDirector>();
        Ondeath();
        jacomecou = PlayerPrefs.GetInt("iniciou"); 
        ini = jacomecou;
        playerPosData = FindObjectOfType<SavePlayer>();
        playerPosData.PlayerPosLoad();
    }
    // atacar no apk:
    public void PowerClick()
    {
        click = true;
    }
    public void Power()
    {
        if(Time.time >= nextAttack)
        {
            if(click == true)
            {
                hit();
                if(hitDirection == 0)
                {
                    click = false;
                    nextAttack = Time.time + 1f / maxTimeAttack;
                    Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(attackDownPos.position, attackRange, whatsIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++) {
                        CreateAttackDownEffect();
                        enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
                        EffectsSong.Bonk();
                    }
                    CreateAttackDownEffect();

                
                }

                if(hitDirection == 1)
                {
                    click = false;
                    nextAttack = Time.time + 1f / maxTimeAttack;
                    Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(attackTopPos.position, attackRange, whatsIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++) {
                        CreateAttackTopEffect();
                        enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
                        EffectsSong.Bonk();
                    }
                    CreateAttackTopEffect();
                }

                if(hitDirection == 2)
                {
                    click = false;
                    nextAttack = Time.time + 1f / maxTimeAttack;
                    // StartCoroutine(TimeAttackTi());
                    Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatsIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++) {
                        CreateAttackRightEffect();
                        enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
                        // EffectsSong.Hit();
                        EffectsSong.Bonk();
                    }
                    CreateAttackRightEffect();
                }

                if(hitDirection == 3)
                {
                    click = false;
                    nextAttack = Time.time + 1f / maxTimeAttack;
                    // StartCoroutine(TimeAttackTi());
                    Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(attackLeftPos.position, attackRange, whatsIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++) {
                        CreateAttackLeftEffect();
                        enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
                        // EffectsSong.Hit();
                        EffectsSong.Bonk();
                    }
                    CreateAttackLeftEffect();
                }
            }
    //  att on pc
            if(Input.GetKeyDown(KeyCode.K))
            {
                hit();
                if(hitDirection == 0)
                {
                    nextAttack = Time.time + 1f / maxTimeAttack;
                    Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(attackDownPos.position, attackRange, whatsIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++) {
                        CreateAttackDownEffect();
                        enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
                        EffectsSong.Bonk();
                    }
                    CreateAttackDownEffect();
                }

                if(hitDirection == 1)
                {
                    nextAttack = Time.time + 1f / maxTimeAttack;
                    StartCoroutine(TimeAttackTi());
                    Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(attackTopPos.position, attackRange, whatsIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++) {
                        CreateAttackTopEffect();
                        enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
                        EffectsSong.Bonk();
                    }
                    CreateAttackTopEffect();
                }

                if(hitDirection == 2)
                {
                    // click = false;
                    nextAttack = Time.time + 1f / maxTimeAttack;
                    StartCoroutine(TimeAttackTi());
                    Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatsIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++) {
                        CreateAttackRightEffect();
                        enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
                        EffectsSong.Bonk();
                    }
                    CreateAttackRightEffect();
                }

                if(hitDirection == 3)
                {
                    nextAttack = Time.time + 1f / maxTimeAttack;
                    StartCoroutine(TimeAttackTi());
                    Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(attackLeftPos.position, attackRange, whatsIsEnemies);
                    for (int i = 0; i < enemiesToDamage.Length; i++) {
                        CreateAttackLeftEffect();
                        enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
                        EffectsSong.Bonk();
                    }
                    CreateAttackLeftEffect();
                }
            }
        }

    }
    private IEnumerator TimeAttackTi()
    {
        yield return new WaitForSeconds (1f);
    }

    private IEnumerator TimeAttack()
    {
        yield return new WaitForSeconds (1);
    }

    // Com botões

    // public void TouchX(int direçao){
    //     auxDirecao = direçao;
    // }

    // public void TouchY(int direçao){
    //     auyDirecao = direçao;
    // }
    // Botões tiro directon

    public void TouchLeft()
    {
        click = true;
        hitDirection = 3;
        if(Time.time >= nextAttack)
        {
            if(click == true)
            {
                hit();
                if(hitDirection == 3)
                {
                    guns[0].gameObject.SetActive(false);
                    guns[1].gameObject.SetActive(false);
                    guns[2].gameObject.SetActive(false);
                    guns[3].gameObject.SetActive(true);
                    click = false;
                    nextAttack = Time.time + 1f / maxTimeAttack;
                }
            }
        }
    }

    public void TouchRight()
    {
        click = true;
        hitDirection = 2;
        if(Time.time >= nextAttack)
        {
            if(click == true)
            {
                hit();
                if(hitDirection == 2)
                {
                    guns[0].gameObject.SetActive(false);
                    guns[1].gameObject.SetActive(false);
                    guns[2].gameObject.SetActive(true);
                    guns[3].gameObject.SetActive(false);
                    click = false;
                    nextAttack = Time.time + 1f / maxTimeAttack;
                }
            }
        }
    }

    public void TouchTop()
    {
        click = true;
        hitDirection = 1;
        if(Time.time >= nextAttack)
        {
            if(click == true)
            {
                hit();
                if(hitDirection == 1)
                {
                    guns[0].gameObject.SetActive(false);
                    guns[1].gameObject.SetActive(true);
                    guns[2].gameObject.SetActive(false);
                    guns[3].gameObject.SetActive(false);
                    click = false;
                    nextAttack = Time.time + 1f / maxTimeAttack;
                }
            }
        }
    }
    public void TouchDown()
    {
        click = true;
        hitDirection = 0;

        if(Time.time >= nextAttack)
        {
            if(click == true)
            {
                hit();
                if(hitDirection == 0)
                {
                    guns[0].gameObject.SetActive(true);
                    guns[1].gameObject.SetActive(false);
                    guns[2].gameObject.SetActive(false);
                    guns[3].gameObject.SetActive(false);
                    click = false;
                    nextAttack = Time.time + 1f / maxTimeAttack;
                }
            }
        }
    }
    //pc
    
    // public void ShotSetas()
    // {
    //     if(Input.GetKey(KeyCode.UpArrow))
    //     {
    //         hitDirection = 1;
    //         nextAttack = Time.time + 1f / maxTimeAttack;
    //         StartCoroutine(TimeAttackTi());
    //         Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(attackTopPos.position, attackRange, whatsIsEnemies);
    //         for (int i = 0; i < enemiesToDamage.Length; i++) {
    //             CreateAttackTopEffect();
    //             enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
    //             EffectsSong.Bonk();
    //         }
    //         CreateAttackTopEffect();
    //     }
    //     if(Input.GetKey(KeyCode.DownArrow))
    //     {
    //         hitDirection = 0;
    //         nextAttack = Time.time + 1f / maxTimeAttack;
    //         Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(attackDownPos.position, attackRange, whatsIsEnemies);
    //         for (int i = 0; i < enemiesToDamage.Length; i++) {
    //             CreateAttackDownEffect();
    //             enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
    //             EffectsSong.Bonk();
    //         }
    //         CreateAttackDownEffect();
    //     }
    //     if(Input.GetKey(KeyCode.RightArrow))
    //     {
    //         hitDirection = 2;
    //         nextAttack = Time.time + 1f / maxTimeAttack;
    //         StartCoroutine(TimeAttackTi());
    //         Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatsIsEnemies);
    //         for (int i = 0; i < enemiesToDamage.Length; i++) {
    //             CreateAttackRightEffect();
    //             enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
    //             EffectsSong.Bonk();
    //         }
    //         CreateAttackRightEffect();
    //     }
    //     if(Input.GetKey(KeyCode.LeftArrow))
    //     {
    //         hitDirection = 3;
    //         nextAttack = Time.time + 1f / maxTimeAttack;
    //         StartCoroutine(TimeAttackTi());
    //         Collider2D[]enemiesToDamage = Physics2D.OverlapCircleAll(attackLeftPos.position, attackRange, whatsIsEnemies);
    //         for (int i = 0; i < enemiesToDamage.Length; i++) {
    //             CreateAttackLeftEffect();
    //             enemiesToDamage[i].GetComponent<EnemyDamage>().TakeDamage(damage);
    //             EffectsSong.Bonk();
    //         }
    //         CreateAttackLeftEffect();
    //     }
    // }
    public void MoveTouch(){
        // Usar no apk mov:

        // Com botões:
        // Vector3 movement = new Vector3(auxDirecao, auyDirecao,  0f);

        // Com joystick:
        Vector3 movement = new Vector3(moveJoystick.Horizontal, moveJoystick.Vertical,  0f);


        // Usar no pc mov:
        // Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),  0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement.normalized * speed * Time.deltaTime;

        // Vector3 dir = new Vector3(moveJoystick.Horizontal)
        // if(transform.position != Vector3.zero)
        // {
        //     tranform.LookAt(transform.position + movement);
        // }

        // Usar no apk mov com joystick:

        if(movement != Vector3.zero)
        {
            anim.SetFloat("HorizontalIdle", movement.x);
            anim.SetFloat("VerticalIdle", movement.y);
            
        }

        // if(anim.SetFloat("HorizontalIdle", movement.y) && movement.y < 0)
        // {
        //     hitDirection = 0;
        // }
        // if(anim.GetFloat("HorizontalIdle", movement.y) && movement.y > 0)
        // {
        //     hitDirection = 1;
        // }

        // if(anim.GetCurrentAnimatorStateInfo(0).IsName("Left"))
        // {
        //     hitDirection = 3;
        // }
        // if (anim.GetCurrentAnimatorStateInfo(0).IsName("Right"))
        // {
        //     hitDirection = 2;
        // }
        // if (anim.GetCurrentAnimatorStateInfo(0).IsName("Top"))
        // {
        //     hitDirection = 1;
        // }
        // if (anim.GetCurrentAnimatorStateInfo(0).IsName("Down"))
        // {
        //     hitDirection = 0;
        // }

        // if(moveJoystick.Horizontal < 0)
        // {
        //     hitDirection = 3;
        //     anim.SetInteger("HitDirecion", 3);

        // }

        // if(moveJoystick.Horizontal > 0)
        // {
        //     hitDirection = 2;
        //     anim.SetInteger("HitDirecion", 2);

        // }

        // if(moveJoystick.Vertical > 0)
        // {
        //     hitDirection = 1;
        //     anim.SetInteger("HitDirecion", 1);

        // }

        // if(moveJoystick.Vertical < 0)
        // {
        //     hitDirection = 0;
        //     anim.SetInteger("HitDirecion", 0);
        // }

        // Usar no apk mov com joystick:

        // if(anim.GetFloat("HorizontalIdle") < 0)
        // {
        //     anim.SetBool("LeftIdle", true);
        //     anim.SetBool("RightIdle", false);
        //     anim.SetBool("TopIdle", false);
        //     anim.SetBool("DownIdle", false);
        //     anim.SetBool("hitting", false);

        //     hitDirection = 3;
        // }

        // if(anim.GetFloat("HorizontalIdle") > 0)
        // {
        //     anim.SetBool("LeftIdle", false);
        //     anim.SetBool("RightIdle", true);
        //     anim.SetBool("TopIdle", false);
        //     anim.SetBool("DownIdle", false);
        //     anim.SetBool("hitting", false);

        //     hitDirection = 2;
        // }

        // if(anim.GetFloat("VerticalIdle") > 0 )
        // {
        //     if(anim.GetFloat("HorizontalIdle") != 0)
        //     {
        //         anim.SetBool("LeftIdle", false);
        //         anim.SetBool("RightIdle", false);
        //         anim.SetBool("TopIdle", true);
        //         anim.SetBool("DownIdle", false);
        //         anim.SetBool("hitting", false);

        //         hitDirection = 1;
        //     }
        // }

        // if(anim.GetFloat("VerticalIdle") < 0)
        // {
        //     if(anim.GetFloat("HorizontalIdle") != 0)
        //     {
        //         anim.SetBool("LeftIdle", false);
        //         anim.SetBool("RightIdle", false);
        //         anim.SetBool("TopIdle", false);
        //         anim.SetBool("DownIdle", true);
        //         anim.SetBool("hitting", false);

        //         hitDirection = 0;
        //     }
        // }

        // Usar no apk mov com botões:

        // if(auxDirecao < 0 )
        // {
        //     anim.SetBool("LeftIdle", true);
        //     anim.SetBool("RightIdle", false);
        //     anim.SetBool("TopIdle", false);
        //     anim.SetBool("DownIdle", false);
        //     anim.SetBool("hitting", false);
        //     hitDirection = 3;

        //     hit();
        // }

        // if(auxDirecao > 0 )
        // {
        //     anim.SetBool("LeftIdle", false);
        //     anim.SetBool("RightIdle", true);
        //     anim.SetBool("TopIdle", false);
        //     anim.SetBool("DownIdle", false);
        //     anim.SetBool("hitting", false);

        //     hitDirection = 2;
        //     hit(); 
        // }

        // if(auyDirecao > 0 )
        // {
        //     anim.SetBool("LeftIdle", false);
        //     anim.SetBool("RightIdle", false);
        //     anim.SetBool("TopIdle", true);
        //     anim.SetBool("DownIdle", false);
        //     anim.SetBool("hitting", false);

        //     hitDirection = 1;
        //     hit();
        // }

        // if(auyDirecao < 0 )
        // {
        //     anim.SetBool("LeftIdle", false);
        //     anim.SetBool("RightIdle", false);
        //     anim.SetBool("TopIdle", false);
        //     anim.SetBool("DownIdle", true);
        //     anim.SetBool("hitting", false);

        //     hitDirection = 0;
        //     hit();
        // }

                // Usar no pc mov:
        
        // if(Input.GetAxisRaw("Horizontal") < 0 )
        // {
        //     anim.SetBool("LeftIdle", true);
        //     anim.SetBool("RightIdle", false);
        //     anim.SetBool("TopIdle", false);
        //     anim.SetBool("DownIdle", false);
        //     anim.SetBool("hitting", false);


        //     // hitDirection = 3;
        // }

        // if(Input.GetAxisRaw("Horizontal") > 0 )
        // {
        //     anim.SetBool("LeftIdle", false);
        //     anim.SetBool("RightIdle", true);
        //     anim.SetBool("TopIdle", false);
        //     anim.SetBool("DownIdle", false);
        //     anim.SetBool("hitting", false);


        //     // hitDirection = 2;
        // }

        // if(Input.GetAxisRaw("Vertical") > 0 )
        // {
        //     anim.SetBool("LeftIdle", false);
        //     anim.SetBool("RightIdle", false);
        //     anim.SetBool("TopIdle", true);
        //     anim.SetBool("DownIdle", false);
        //     anim.SetBool("hitting", false);


        //     // hitDirection = 1;
        // }

        // if(Input.GetAxisRaw("Vertical") < 0 )
        // {
        //     anim.SetBool("LeftIdle", false);
        //     anim.SetBool("RightIdle", false);
        //     anim.SetBool("TopIdle", false);
        //     anim.SetBool("DownIdle", true);
        //     anim.SetBool("hitting", false);

        //     // hitDirection = 0;
        // }

    }
    // Atacar
    private void hit()
    {
        anim.SetTrigger("attack");
        gun.SetTrigger("attack");

        if(hitDirection == 3) {
            guns[0].gameObject.SetActive(false);
            guns[1].gameObject.SetActive(false);
            guns[2].gameObject.SetActive(false);
            guns[3].gameObject.SetActive(true);
            if(lantDir != 4)
            {
                Lantern_On();
            }
            GameObject bullet = Instantiate(bulletLeftPrefab, firepointLeft.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepointLeft.right *- bulletForce, ForceMode2D.Impulse);
            Destroy(bullet.gameObject, 2f);
        }

        if(hitDirection == 2) {
            guns[0].gameObject.SetActive(false);
            guns[1].gameObject.SetActive(false);
            guns[2].gameObject.SetActive(true);
            guns[3].gameObject.SetActive(false);
            if(lantDir != 4)
            {
                Lantern_On();
            }
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet.gameObject, 2f);

        }

        if(hitDirection == 1) {
            guns[0].gameObject.SetActive(false);
            guns[1].gameObject.SetActive(true);
            guns[2].gameObject.SetActive(false);
            guns[3].gameObject.SetActive(false);
            if(lantDir != 4)
            {
                Lantern_On();
            }
            GameObject bullet = Instantiate(bulletTopPrefab, firepointTop.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepointTop.up * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet.gameObject, 2f);

        }

        if(hitDirection == 0) {
            guns[0].gameObject.SetActive(true);
            guns[1].gameObject.SetActive(false);
            guns[2].gameObject.SetActive(false);
            guns[3].gameObject.SetActive(false);
            if(lantDir != 4)
            {
                Lantern_On();
            }
            GameObject bullet = Instantiate(bulletDownPrefab, firepointDown.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepointDown.up *- bulletForce, ForceMode2D.Impulse);
            Destroy(bullet.gameObject, 2f);

        }
    }

    void OnDrawGizmosSelected() {
        if(hitDirection == 2)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
        if(hitDirection == 3)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(attackLeftPos.position, attackRange);
        }
        if(hitDirection == 1)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(attackTopPos.position, attackRange);
        }
        if(hitDirection == 0)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(attackDownPos.position, attackRange);
        }

    }

    private IEnumerator TimeKillCoroutine()
    {
        yield return new WaitForSeconds (1);
        if(life <= 0)
        {
            Ondeath();
        }
        if(cena)
        {
            direco.gameObject.SetActive(false);
        }
    }

    private void Ondeath()
    {
        if(life <= 0)
        {
            EndGame.lifesU += 1;
            coinsOn.SetLifes(EndGame.lifesU);
        }
    }

    public void StartTimeLine()
    {
        life = 3;
        transform.position = respawnPoint;
        initScene.iniciou += 1;
        cena = true;
        StartCoroutine (TimeKillCoroutine());
        cena = false;
    }

    // Levar dano 
    public void TakeDamage(int DamagedGhost)
    {
        EffectsSong.Hit();
        life -= DamagedGhost;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        if(life <= 0)
        {

        }
    }

    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void Lantern_On()
    {
        lanternOff.gameObject.SetActive(true);
        lanternOn.gameObject.SetActive(false);
        if(hitDirection == 0)
        {
            lantDir = 0;
            if(lantDir == 0)
            {
                guns_Light[0].gameObject.SetActive(false);
                guns_Light[1].gameObject.SetActive(false);
                guns_Light[2].gameObject.SetActive(false);
                guns_Light[3].gameObject.SetActive(false);
                guns_Light[4].gameObject.SetActive(false);
                guns_Light[5].gameObject.SetActive(false);
                guns_Light[6].gameObject.SetActive(true);
                guns_Light[7].gameObject.SetActive(true);
            }
        }

        if(hitDirection == 1)
        {
            lantDir = 1;
            if(lantDir == 1)
            {
                guns_Light[0].gameObject.SetActive(false);
                guns_Light[1].gameObject.SetActive(false);
                guns_Light[2].gameObject.SetActive(false);
                guns_Light[3].gameObject.SetActive(false);
                guns_Light[4].gameObject.SetActive(true);
                guns_Light[5].gameObject.SetActive(true);
                guns_Light[6].gameObject.SetActive(false);
                guns_Light[7].gameObject.SetActive(false);
            }

        }

        if(hitDirection == 2)
        {
            lantDir = 2;
            if(lantDir == 2)
            {
                guns_Light[0].gameObject.SetActive(true);
                guns_Light[1].gameObject.SetActive(true);
                guns_Light[2].gameObject.SetActive(false);
                guns_Light[3].gameObject.SetActive(false);
                guns_Light[4].gameObject.SetActive(false);
                guns_Light[5].gameObject.SetActive(false);
                guns_Light[6].gameObject.SetActive(false);
                guns_Light[7].gameObject.SetActive(false);
            }


        }

        if(hitDirection == 3)
        {
            lantDir = 3;
             if(lantDir == 3)
            {
                guns_Light[0].gameObject.SetActive(false);
                guns_Light[1].gameObject.SetActive(false);
                guns_Light[2].gameObject.SetActive(true);
                guns_Light[3].gameObject.SetActive(true);
                guns_Light[4].gameObject.SetActive(false);
                guns_Light[5].gameObject.SetActive(false);
                guns_Light[6].gameObject.SetActive(false);
                guns_Light[7].gameObject.SetActive(false);
            }
        }
    }
    public void Lantern_Off()
    {
        lanternOn.gameObject.SetActive(true);
        lanternOff.gameObject.SetActive(false);
        guns_Light[0].gameObject.SetActive(false);
        guns_Light[1].gameObject.SetActive(false);
        guns_Light[2].gameObject.SetActive(false);
        guns_Light[3].gameObject.SetActive(false);
        guns_Light[4].gameObject.SetActive(false);
        guns_Light[5].gameObject.SetActive(false);
        guns_Light[6].gameObject.SetActive(false);
        guns_Light[7].gameObject.SetActive(false);
        lantDir = 4;
    }

    public void Continue()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Creditos()
    {
        credito.SetActive(true);
    }
    public void Doar()
    {
        doar.SetActive(true);
    }

    public void BackOptions()
    {
        credito.SetActive(false);
        doar.SetActive(false);
        // Time.timeScale = 1;
    }

    void CreateAttackLeftEffect()
    {
        effectkAttackLeft.Play();
    }

    void CreateAttackRightEffect()
    {
        effectkAttackRight.Play();
    }

    void CreateAttackTopEffect()
    {
        effectkAttackTop.Play();
    }

    void CreateAttackDownEffect()
    {
        effectkAttackDown.Play();
    }
}