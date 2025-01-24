using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject creditos;
    // public GameObject idioma;

    [SerializeField] private string sceneName;

    public GameObject CanvaPainel;


    public void StartGame()
    {
        PlayerPrefs.DeleteKey("iniciou");
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        SceneLoad.Instance.LoadSceneAsync(sceneName);
        CanvaPainel.SetActive(false);
        Time.timeScale = 1f;
    }

    // public void Idioma()
    // {

    // }

    public void Creditos()
    {
        creditos.SetActive(true);
    }

    public void Back()
    {
        creditos.SetActive(false);
    }

}