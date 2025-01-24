using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDestroier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "spawner") {
            StartCoroutine(TempoSpawner());
        }
            
            // Debug.Log(target);
    }   
    private IEnumerator TempoSpawner()
    {
        yield return new WaitForSeconds (0.5f);
        gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
    // private void OnTriggerExit2D(Collider2D other) {
    //      if(other.gameObject.tag == "Player") {
    //     }
    // }
}
