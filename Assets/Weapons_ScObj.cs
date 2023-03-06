using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Create Weapon")]
public class Weapons_ScObj : ScriptableObject
{
    public GameObject Weapon_Obj;
    public SpriteRenderer Weapon_Sprite; 
    public float Dmg = 100;
    public float RMP = 50;
    public float Magazine = 12;
    public float Ammo_Max = 300;
    public string Element_Type = "Kinetic";
}
