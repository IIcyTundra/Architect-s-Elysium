using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpawner : MonoBehaviour
{
    public GameObject PU;
    public float PUTimer;

    public void Start()
    {
        CreatePU();
        StartCoroutine(LoadPU(PUTimer));  
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadPU(PUTimer));
        }
    }

    IEnumerator LoadPU(float timer)
    {
        if(PU != null)
            BulletBehavior.Takeobj(PU);

        yield return new WaitForSeconds(timer);

        CreatePU();
   
    }

    public void CreatePU()
    {
        PU = BulletBehavior.GiveObj(0);
        if (PU != null)
        {
            PU.transform.SetPositionAndRotation(transform.position, transform.rotation);
            PU.SetActive(true);
        }
    }



    
}
