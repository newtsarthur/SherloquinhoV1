using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    public player playerDados;
    public initScene initScene;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            // int lifeSave = playerDados.lifeSave;
            int iniciou = playerDados.jacomecou;

            // lifeSave = PlayerPrefs.GetInt("lifeSave");
            iniciou = PlayerPrefs.GetInt("iniciou");

            // playerDados.lifeSave = lifeSave;
            playerDados.jacomecou = iniciou;

        }
    }

    public void PlayerPosSave()
    {
        // PlayerPrefs.SetFloat("lifeSave", playerDados.lifeSave);


        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
        
        PlayerPrefs.SetInt("iniciou", playerDados.jacomecou);

        // ini
    } 

    public void PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }

    
}
