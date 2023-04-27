using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_Function_Handler : MonoBehaviour
{
    [SerializeField] private GameObject PlayerUI;
    [SerializeField] private Transform[] Weapons;
    [SerializeField] private KeyCode[] Keys;
    [SerializeField] private float SwapTime;
    

    private int selectedWeapon;
    private float timeSinceLastSwitch;
    int previousSelectedWeapon;


    private void Start() {
        SetWeapons();
        Select(selectedWeapon);
        timeSinceLastSwitch = 0f;
    }

    private void SetWeapons() {
        Weapons = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            Weapons[i] = transform.GetChild(i);

        if (Keys == null) Keys = new KeyCode[Weapons.Length];
    }

    private void Update() {
        previousSelectedWeapon = selectedWeapon;
        KeySwap();
        ScrollSwap();
        timeSinceLastSwitch += Time.deltaTime;
    }

    private void Select(int weaponIndex) {
        for (int i = 0; i < Weapons.Length; i++)
            Weapons[i].gameObject.SetActive(i == weaponIndex);

        timeSinceLastSwitch = 0f;

    }

    private void KeySwap()
    {
        for (int i = 0; i < Keys.Length; i++)
            if (Input.GetKeyDown(Keys[i]) && timeSinceLastSwitch >= SwapTime)
                selectedWeapon = i;

        if (previousSelectedWeapon != selectedWeapon) Select(selectedWeapon);
    }

    private void ScrollSwap()
    {
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if(ScrollWheel > 0f)
        {
            if((selectedWeapon >= transform.childCount-1) && (timeSinceLastSwitch >= SwapTime))
            {
                selectedWeapon = 0;
                if (previousSelectedWeapon != selectedWeapon) Select(selectedWeapon);
            }
            else if(timeSinceLastSwitch >= SwapTime)
            {
                selectedWeapon++;
                if (previousSelectedWeapon != selectedWeapon) Select(selectedWeapon);
            }
        }
        else if (ScrollWheel < 0f) 
        {
            if((selectedWeapon <= 0) && (timeSinceLastSwitch >= SwapTime))
            {
                selectedWeapon = transform.childCount-1;
                if (previousSelectedWeapon != selectedWeapon) Select(selectedWeapon);
            }
            else if(timeSinceLastSwitch >= SwapTime){
                selectedWeapon--;
                if (previousSelectedWeapon != selectedWeapon) Select(selectedWeapon);
            }
        }


    }
}
