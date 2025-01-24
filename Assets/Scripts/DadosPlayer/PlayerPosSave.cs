// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SavePosPlayer : MonoBehaviour
// {
//     public GameObject player;
//     public GameObject cenaDeQueda;
//     public player playerDados;

//     // void Awake()
//     // {
//     //     playerDados = FindObjectOfType<movimentation_player>();
//     // }

//     public void Start()
//     {
//         // playerDados = FindObjectOfType<player>();
//         if(PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
//         {
//             // float pX = player.transform.position.x;
//             // float pY = player.transform.position.y;
//             // float pZ = player.transform.position.z;
//             // float songCachoeira = playerDados.somC;
//             // float songPiano = playerDados.pianoOn;
//             // float somFloresta = playerDados.somDaFlorestaSave;
//             // float volMaster = playerDados.settingsVolume.volumeMaster;
//             // float volMusica = playerDados.settingsVolume.volumeMusica;


//             int lifeSave = playerDados.lifeSave;
//             // int dash = playerDados.addDash;
//             // int wall = playerDados.addWall;
//             // int Fchave = playerDados.addFragmentoDeChave;
//             // int Nmortes = playerDados.killedPlayer;
//             // int Ncoins = playerDados.coinsPlayer;

//             // string Ncena = playerDados.cenaAtual;


//             // pX = PlayerPrefs.GetFloat("p_x");
//             // pY = PlayerPrefs.GetFloat("p_y");
//             // pZ = PlayerPrefs.GetFloat("p_z");

//             // songCachoeira = PlayerPrefs.GetFloat("songAgua");
//             // songPiano = PlayerPrefs.GetFloat("somPianoWild");
//             // somFloresta = PlayerPrefs.GetFloat("songFloresta");
//             // volMaster = PlayerPrefs.GetFloat("volumeMaster");
//             // volMusica = PlayerPrefs.GetFloat("volumeMusica");

//             lifeSave = PlayerPrefs.GetInt("lifeSave");
//             // dash = PlayerPrefs.GetInt("dash");
//             // wall = PlayerPrefs.GetInt("wall");
//             // Fchave = PlayerPrefs.GetInt("fragChaves");
//             // Nmortes = PlayerPrefs.GetInt("Nmortes");
//             // Ncoins = PlayerPrefs.GetInt("Coins");

//             // Ncena = PlayerPrefs.GetString("Cena");

//             // playerDados.somC = songCachoeira;
//             // playerDados.pianoOn = songPiano;
//             // playerDados.somDaFlorestaSave = somFloresta;
//             playerDados.lifeSave = lifeSave;
//             // playerDados.addDash = dash;
//             // playerDados.addWall = wall;
//             // playerDados.addFragmentoDeChave = Fchave;
//             // playerDados.killedPlayer = Nmortes;
//             // playerDados.coinsPlayer = Ncoins;
//             // playerDados.settingsVolume.volumeMaster = volMaster;
//             // playerDados.settingsVolume.volumeMusica = volMusica;
//             // playerDados.cenaAtual = Ncena;


//             // player.transform.position = new Vector3(pX, pY, -12f);
//             PlayerPrefs.SetInt("TimeToLoad", 0);
//             PlayerPrefs.Save();
//         }
//         // else
//         // {
//         //     cenaDeQueda.SetActive(true);
//         // }
//     }

//     public void PlayerPosSave()
//     {
//         // PlayerPrefs.SetFloat("p_x", player.transform.position.x);
//         // PlayerPrefs.SetFloat("p_y", player.transform.position.y);
//         // PlayerPrefs.SetFloat("p_z", player.transform.position.z);
//         // PlayerPrefs.SetFloat("songAgua", playerDados.somC);
//         // PlayerPrefs.SetFloat("somPianoWild", playerDados.pianoOn);
//         // PlayerPrefs.SetFloat("songFloresta", playerDados.somDaFlorestaSave);
//         PlayerPrefs.SetFloat("lifeSave", playerDados.lifeSave);

//         // PlayerPrefs.SetFloat("volumeMaster", playerDados.settingsVolume.volumeMaster);
//         // PlayerPrefs.SetFloat("volumeMusica", playerDados.settingsVolume.volumeMusica);

//         // PlayerPrefs.SetInt("dash", playerDados.addDash);
//         // PlayerPrefs.SetInt("wall", playerDados.addWall);
//         // PlayerPrefs.SetInt("fragChaves", playerDados.addFragmentoDeChave);
//         // PlayerPrefs.SetInt("Nmortes", playerDados.killedPlayer);
//         // PlayerPrefs.SetInt("Coins", playerDados.coinsPlayer);

//         // PlayerPrefs.SetString("Cena", playerDados.cenaAtual);

//         // aguaAtiva = playerDados.verificaSong;


//         PlayerPrefs.SetInt("Saved", 1);
//         PlayerPrefs.Save();
//     }

//     public void PlayerPosLoad()
//     {
//         PlayerPrefs.SetInt("TimeToLoad", 1);
//         PlayerPrefs.Save();
//     }
// }
