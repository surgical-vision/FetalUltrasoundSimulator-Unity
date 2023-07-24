using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityVolumeRendering
{
    public class PlayerCollision : MonoBehaviour
    {

        // private void OnTriggerEnter2D(Collider2D collision)
        // {
        //     ProcessCollision(collision.gameObject);
        // }

        // private void OnCollisionEnter2D(Collision2D collision)
        // {
        //     ProcessCollision(collision.gameObject);
        // }

        // void ProcessCollision(GameObject collider)
        // {
        //     if(collider.CompareTag("Shell"))
        //     {
        //         CollisionEvent();
        //     }
        // }

        // void CollisionEvent()
        // {
        //     Debug.Log("Hit!");
        // }

        void OnCollisionEnter(Collision coll)
        {
            print("Collision");

            // if(coll.transform.tag == "Shell")
            // {
            //     Debug.Log("Collision with Shell Detected");
            // }
        }
    }
}