using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlies : MonoBehaviour
{
    public Transform firefliePos;
    public float flyRange;
    private float speed = 0.5f;

    void Update()
    {
         Fly();
    }
    void Fly()
    {
        float x = Random.Range( -firefliePos.localScale.x, firefliePos.localScale.x);
        float y = Random.Range( -firefliePos.localScale.y, firefliePos.localScale.y);
        Vector3 movement = new Vector3(x, y,  0f);
        transform.position = transform.position + movement.normalized * speed * Time.deltaTime;
    }
}
