using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Create Scriptable Object/Weapon")]
public class Weapons_ScObj : ScriptableObject
{
    public Sprite WeaponSprite;
    [Header ("Weapon Stats")]
    public float Dmg = 100;
    public float RMP = 50;
    public float Magazine = 12;
    public float Ammo_Max = 300;
    public string Element_Type;
}
