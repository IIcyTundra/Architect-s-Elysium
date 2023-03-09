using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Create Scriptable Object/Weapon/MA40")]
public class Weapons_ScObj : ScriptableObject
{
    [Header("Object References")]
    #region Obj References
    public string Weapon_Name = "MA40";
    
    //Reference to the Gun Object
    public GameObject MA40;
    
    //Reference to the Bullet Object
    public GameObject Bullet_Prefab;
   
    //Reference to the Grenade Object
    public GameObject Grenade_Prefab;

    //Reference to the weapon Reticle
    public SpriteRenderer Weapon_Reticle;
    #endregion
    
    [Header ("Weapon Stats")]
    #region Weapon Stats
    //Weapon Kinetic Damage
    public float KDmg = 75; 
    
    //Weapon Explosive Damage
    public float EDmg = 140; 
    
    //Weapon Rate of Fire
    public float ROF = 50; 
    
    //Max Ammount of ammo you can carry
    public const int Ammo_Max = 300; 
    public const int G_Ammo_Max = 7;
    
    //Weapon Elemental Type (Sometimes they can hold more than one)
    public string[] Element_Type = {"Kinetic", "Explosive"}; 

    //Weapon shot spread. On initial shot, the angle or "cone" will spread out to it's max angle
    public float Shot_Spread = 0.7f; 
    #endregion
   
    //--------------------------------------------------------------------------------------------

    #region Ammo/Shooting Handler
    int Ammo_left_in_mag = Ammo_Max;
    int G_ammo_left = G_Ammo_Max;



    public void fire()
    {
        if(Ammo_left_in_mag == 0)
            Debug.log("No ammo Left");
        else
        Ammo_left_in_mag--;


    }
    public void AltFire()
    {
        if(G_ammo_left == 0)
            Debug.log("No ammo Left");
        else
        G_ammo_left--;
    }

    public void Add_Ammo(int AmmoAdded)
    {
        if(Ammo_left_in_mag <= Ammo_Max)
        {
            Ammo_left_in_mag += AmmoAdded;
        }
        else if (Ammo_left_in_mag >Ammo_Max)
        {
            Ammo_left_in_mag == Ammo_Max;
        }
    }
    #endregion
 
}
