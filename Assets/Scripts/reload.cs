using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviour {

   string nomeDaCenaAtual;
   public player player;
   public initScene initScene;

   void Start () {
      // player = GameObject<player>();
      // if(PlayerPrefs.GetInt("iniciou") != 1)
      // {
      // }
      initScene = FindObjectOfType<initScene>();
      nomeDaCenaAtual = SceneManager.GetActiveScene ().name;

   }

   void Update () {
      if (player.life <= 0) {
         // ReloadTime();
      //    if(PlayerPrefs.GetInt("iniciou") >= 1)
      //   {
      //   }
         SceneManager.LoadScene(nomeDaCenaAtual);

      }
   }
   public void Recarregar()
   {
         PlayerPrefs.DeleteKey("iniciou");
         // initScene.iniciou = 0;

         // initScene.iniciou += 1;

         SceneManager.LoadScene(nomeDaCenaAtual);
   }
   // private IEnumerator ReloadTime()
   // {
   //    yield return new WaitForSeconds (1);
   // }

}