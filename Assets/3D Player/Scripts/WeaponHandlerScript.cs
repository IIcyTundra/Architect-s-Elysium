using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHandlerScript : MonoBehaviour
{
    public Transform GunDir;
    public LineRenderer LineRend;
    public Weapon_Base_Script WeaponReference;
    public Image WeaponImage;

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
        RaycastHit hit;
        

        if(Physics.Raycast(GunDir.position, GunDir.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 5))
        {
            LineRend.enabled = true;
            LineRend.SetPosition(0,GunDir.transform.position);
            LineRend.SetPosition(1,hit.point);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log("Did Hit");
            
        }
        else
        {
            LineRend.enabled=false;
        }
        
    }
}
