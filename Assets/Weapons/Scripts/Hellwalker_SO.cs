using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hellwalker", menuName = "Create Scriptable Object/HellWalker")]
public class Hellwalker_SO : ScriptableObject
{
    public GameObject HW_Obj;
    public string HW_Name = "Hellwalker";
    public int HW_ID = 1;
    public float HW_Range = 5f;
    public int HW_Ammo_Max = 8;
    public float HW_SpreadAngle = 20f; //Cone Angle
    public float HW_Radius = 10f; //Cone Radius
}
