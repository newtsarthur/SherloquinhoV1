using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_controler : MonoBehaviour
{
    public static game_controler gameController;
    public EndGame EndGame;

    public GameObject explosion;
    public ParticleSystem explosionAdd;
    public ParticleSystem explosionAddTwo;



    // public Text coinsText;

    public Text killsText;
    
    public Text lifesText;


    public int killeds;
    public int lifesUsadas;

    void Awake()
    {
        if(gameController == null)
        {
            gameController = this;
        }
    }

    // enviar número de mortes
    public void SetKills(int k)
    {
        killeds = k;
        CreateEffect();
        UpdateHUD();
    }
    public int GetKills()
    {
        return killeds;
    }

    // enviar número de vidas usadas
    public void SetLifes(int w)
    {
        lifesUsadas = w;
        CreateEffectTwo();
        UpdateHUD();
    }
    public int GetLifes()
    {
        return lifesUsadas;
    }

    // enviar número de coins
    // public void SetCoins(int c)
    // {
    //     coins = c;
    //     UpdateHUD();
    // }

    // public int GetCoins()
    // {
    //     return coins;
    // }

    public void UpdateHUD()
    {
        lifesText.text = GetLifes().ToString();
        killsText.text = GetKills().ToString();
    }

    void CreateEffect()
    {
        // explosion.gameObject.SetActive(true);
        explosionAdd.Play();
        // explosion.gameObject.SetActive(false);
    }
    void CreateEffectTwo()
    {
        // explosion.gameObject.SetActive(true);
        explosionAddTwo.Play();
        // explosion.gameObject.SetActive(false);
    }
}
