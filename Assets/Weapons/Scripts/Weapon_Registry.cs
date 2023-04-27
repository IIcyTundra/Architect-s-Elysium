using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon_Registry", menuName = "Create Scriptable Object/Weapon Registry")]
public class Weapon_Registry : ScriptableObject
{
    public Dictionary<int, string> W_Dic = new Dictionary<int, string>()
    {
        {0, "MR45"},
        {1,"Hellwalker"},
        {2,"ION CASTER"},
        {3,"Durendal"}
    };
}
