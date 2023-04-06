using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMechanics : MonoBehaviour
{
    public float delay = 6f;
//     void Start()
//     {
//         Destroy(gameObject, delay);
//     }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 15);
        }
    }
}
