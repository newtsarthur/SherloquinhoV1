// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ToolController : MonoBehaviour
// {
//     player player;

//     Rigidbody2D rb;

//     private void Awake()
//     {
//         player = GetComponent<player>();
//         rb = GetComponent<Rigidbody2D>();
//     }
//     private void UseTool()
//     {
//         Vector2 pos = rb.position + player.lastPos * offsetDistance;
//         Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, pickupZone);

//         foreach(Collider2D c in Colliders)
//         {
//             Tool hit = c.GetComponent<Tool>();
//             if(hit != null)
//             {
//                 hit.Hit();
//                 break;
//             }
//         }
//     }
// }
