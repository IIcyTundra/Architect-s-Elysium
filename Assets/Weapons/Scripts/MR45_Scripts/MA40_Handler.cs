using UnityEngine;
using TMPro;

public class MA40_Handler : MonoBehaviour
{
    // public Weapon_SO Weapon_Ref;
    // public TextMeshProUGUI AmmoRef;
    // RaycastHit RayHit;
    // int bulletsLeft, bulletsShot;
    // bool shooting, readyToShoot, reloading, allowInvoke;
    // public GameObject Weapon_AP;
    // public AudioSource audioSource; 
    // public LayerMask Enemy; 
    // float zRotation;
    // TextMeshProUGUI Ammo; 


    // private void Awake()
    // {
    //     bulletsLeft = Weapon_Ref.Weapon_Ammo_Mag;
    //     readyToShoot = true;

    //     audioSource = GetComponent<AudioSource>();
    //     Weapon_Ref.PlayerCam = GetComponentInParent<Camera>();

    // }
    
    // private void Update()
    // {
    //     MyInput();

    //     //SetText
    //     AmmoRef.SetText(bulletsLeft/Weapon_Ref.Weapon_Bull_Per_Tap + 
    //     "/" + Weapon_Ref.Weapon_Ammo_Mag/Weapon_Ref.Weapon_Bull_Per_Tap);
    // }
    // private void MyInput()
    // {
    //     if (Weapon_Ref.FullAutoToggle) shooting = Input.GetKey(KeyCode.Mouse0);
    //     else shooting = Input.GetKeyDown(KeyCode.Mouse0);

    //     if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < Weapon_Ref.Weapon_Ammo_Mag && !reloading) Reload();

    //     //Shoot
    //     if (readyToShoot && shooting && !reloading && bulletsLeft > 0){
    //         bulletsShot = Weapon_Ref.Weapon_Bull_Per_Tap;
    //         Shoot();
            
    //     }
    // }

    // public void Shoot()
    // {

    //     audioSource.Stop();
    //     audioSource.clip = Weapon_Ref.shootSounds[Random.Range(0, Weapon_Ref.shootSounds.Length)];
    //     audioSource.Play();

    //     //Spread
    //     float x = Random.Range(-Weapon_Ref.Weapon_Spread, Weapon_Ref.Weapon_Spread);
    //     float y = Random.Range(-Weapon_Ref.Weapon_Spread, Weapon_Ref.Weapon_Spread);
    //     Vector3 direction = Weapon_Ref.PlayerCam.transform.forward + new Vector3(x,y,0);
    //     GameObject thisFlash = Instantiate(Weapon_Ref.MuzzleFlash, Weapon_AP.transform.position,
    //      Quaternion.Euler(Weapon_AP.transform.rotation.x,Weapon_AP.transform.rotation.y,Weapon_AP.transform.rotation.z));

    //     if (allowInvoke)
    //     {
    //         Invoke("ResetShot", Weapon_Ref.Weapon_TBShooting);
    //         allowInvoke = false;
    //     }

    //     //Debug.DrawRay(Weapon_Ref.PlayerCam.transform.position, Weapon_Ref.PlayerCam.transform.forward * Weapon_Ref.Weapon_Range, Color.green);
    //     readyToShoot = false;

    //     //Check if we hit something
    //     if (Physics.Raycast(Weapon_Ref.PlayerCam.transform.position, direction, out RayHit, Weapon_Ref.Weapon_Range))
    //     { 
    //         Debug.DrawRay(Weapon_Ref.PlayerCam.transform.position, direction * Weapon_Ref.Weapon_Range, Color.green);
    //         //Debug.Log(RayHit.collider);
    //         if(RayHit.collider.tag == "Enemy")
    //         {
    //             RayHit.collider.GetComponent<EnemyBehavior>().TakeDamage(Weapon_Ref.Weapon_DMG, Weapon_Ref.Weapon_Effect);
    //         }

    //     }

    //     bulletsLeft--;
    //     bulletsShot--;

    //     Invoke("ResetShot", Weapon_Ref.Weapon_TBShooting);

    //     if(bulletsShot > 0 && bulletsLeft > 0)
    //     Invoke("Shoot", Weapon_Ref.Weapon_TBShots);

    //     Destroy(thisFlash, 0.5f);
    // }

    // public void ResetShot()
    // {
    //     readyToShoot = true;
    //     allowInvoke = true;
    // }
    // public void Reload()
    // {
    //     audioSource.clip = Weapon_Ref.reloadSounds[Random.Range(0, Weapon_Ref.reloadSounds.Length)];
    //     audioSource.Play();
    //     reloading = true;
    //     Invoke("ReloadFinished", Weapon_Ref.Weapon_Reload_Speed);
    // }
    // private void ReloadFinished()
    // {
    //     bulletsLeft = Weapon_Ref.Weapon_Ammo_Mag;
    //     reloading = false;
    // }
    
     
}  
