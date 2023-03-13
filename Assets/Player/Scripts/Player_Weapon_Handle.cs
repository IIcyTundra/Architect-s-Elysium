using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Weapon_Handle : MonoBehaviour
{
    public Camera cam;
    public GameObject PlayerCursor;

    // Update is called once per frame
    void Update()
    { 

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Debug.Log("Shoot fired");
    }
}
