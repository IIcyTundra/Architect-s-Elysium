
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Create Scriptable Object/Base Weapon Script")]
public class Weapon_Base_Script : ScriptableObject
{
    public List<GameObject> WeaponList = new List<GameObject>(); 
    public Dictionary<string, int> WeaponDirectory = new Dictionary<string, int>()
    {
        {"MA40", 0 },
        {"Hellwalker", 1},
        {"Durendal", 2},
        {"ION CASTER", 3}
    };


    

    



    
}
