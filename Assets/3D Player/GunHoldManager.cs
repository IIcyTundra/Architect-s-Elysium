using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHoldManager : MonoBehaviour
{
    public Player_SO Chosen;
    public GameObject HW;
    public GameObject MA40;

    
    private void Update()
    {
        if(Chosen.WeaponChoice == 0)
        {
            HW.SetActive(true);
            MA40.SetActive(false);
        }
        else if(Chosen.WeaponChoice == 1)
        {
            MA40.SetActive(true);
            HW.SetActive(false);
        }
    }


    
}
