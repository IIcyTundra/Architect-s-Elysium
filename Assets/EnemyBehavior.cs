using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public float Health = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float DMG, string effect)
    {
        if(effect.CompareTo("Incendiary") == 0)
        {
            Health -= DMG;
            StartCoroutine(DMGOverTime(1));
        }
        
    }

    IEnumerator DMGOverTime(int time)
    {
        while(Health != 0 && time != 10)
        {
            Health -=5;
            yield return new WaitForSeconds(time);
            time++;
            Debug.Log(time);
        }
        

        
    }

    
}
