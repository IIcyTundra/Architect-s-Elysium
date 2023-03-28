using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HellWalker", menuName = "Create Scriptable Object/HellWalker")]
public class Hellwalker_SO : ScriptableObject
{
    public GameObject HW_Obj;
    public Sprite HW_Sprite;
    public string HW_Name = "Hellwalker";
    public int HW_ID = 1;
    public float HW_Range = 5f;
    public int HW_Ammo_Max = 40;
    public float HW_Spread = 0.9f;
}
