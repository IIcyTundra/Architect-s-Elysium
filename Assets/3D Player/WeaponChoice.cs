using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponChoice : MonoBehaviour
{
    public Player_SO WC;
    
    public void MA40()
    {
        WC.WeaponChoice = 0;
        SceneManager.LoadScene(2);
    }

    public void HellWalker()
    {
        WC.WeaponChoice = 1;
        SceneManager.LoadScene(2);
    }
}
