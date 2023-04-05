using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class HW_Handler : MonoBehaviour
{
    public Weapon_SO Weapon_Ref;
    RaycastHit RayHit;
    int bulletsLeft, bulletsShot;
    bool shooting, readyToShoot, reloading, allowInvoke;
    public GameObject Weapon_AP;
    public AudioSource audioSource; 
    public LayerMask Enemy; 
    TextMeshProUGUI Ammo;
  
    private void Awake()
    {
        bulletsLeft = Weapon_Ref.Weapon_Ammo_Mag;
        readyToShoot = true;
        audioSource = GetComponent<AudioSource>();
        Weapon_Ref.PlayerCam = GetComponentInParent<Camera>();
        Ammo = Component.FindObjectOfType<TextMeshProUGUI>();
    }
    
    private void Update()
    {
        MyInput();
        //SetText

        Ammo.SetText(bulletsLeft/Weapon_Ref.Weapon_Bull_Per_Tap + 
        "/" + Weapon_Ref.Weapon_Ammo_Mag/Weapon_Ref.Weapon_Bull_Per_Tap);
        
    }
    private void MyInput()
    {
        if (Weapon_Ref.FullAutoToggle) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < Weapon_Ref.Weapon_Ammo_Mag && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0){
            bulletsShot = Weapon_Ref.Weapon_Bull_Per_Tap;
            Shoot();
        }
    }

    public void Shoot()
    {
        audioSource.Stop();
        audioSource.clip = Weapon_Ref.shootSounds[Random.Range(0, Weapon_Ref.shootSounds.Length)];
        audioSource.Play();
        
        GameObject thisFlash = Instantiate(Weapon_Ref.MuzzleFlash, Weapon_AP.transform.position, Quaternion.identity);

        if (allowInvoke)
        {
            Invoke("ResetShot", Weapon_Ref.Weapon_TBShooting);
            allowInvoke = false;
        }
       
        
        readyToShoot = false;

        

        //Spread
        float x = Random.Range(-Weapon_Ref.Weapon_Spread, Weapon_Ref.Weapon_Spread);
        float y = Random.Range(-Weapon_Ref.Weapon_Spread, Weapon_Ref.Weapon_Spread);

        //Ray ray = Weapon_Ref.PlayerCam.ViewportPointToRay(new Vector3(x,y,0));
        Vector3 direction = Weapon_Ref.PlayerCam.transform.forward + new Vector3(x,y,0);
        //Check if we hit something
        if (Physics.Raycast(Weapon_Ref.PlayerCam.transform.position, direction, out RayHit, Weapon_Ref.Weapon_Range))
        { 
            Debug.DrawRay(Weapon_Ref.PlayerCam.transform.position, direction * Weapon_Ref.Weapon_Range, Color.green);
            Debug.Log(RayHit.collider);
            if(RayHit.collider.tag == "Enemy")
            {
                RayHit.collider.GetComponent<EnemyBehavior>().TakeDamage(Weapon_Ref.Weapon_DMG, Weapon_Ref.Weapon_Effect);
            }

        }
        //Instantiate(Weapon_Ref.Weapon_BHole, RayHit.point, Quaternion.FromToRotation(direction, RayHit.normal));
        

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", Weapon_Ref.Weapon_TBShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", Weapon_Ref.Weapon_TBShots);

        Destroy(thisFlash, 0.5f);
    }

    public void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
    public void Reload()
    {
        reloading = true;
        StartCoroutine(EachShellPlaced(Weapon_Ref.Weapon_Reload_Speed));
    }
    private void ReloadFinished()
    {
        audioSource.PlayOneShot(Weapon_Ref.reloadSounds[7]);
        bulletsLeft = Weapon_Ref.Weapon_Ammo_Mag;
        reloading = false;
    }

    public IEnumerator EachShellPlaced(float reloadTime)
    {
        while (bulletsLeft < Weapon_Ref.Weapon_Ammo_Mag)
        {
            bulletsLeft += 8;
            if(audioSource != null)
            {
                audioSource.PlayOneShot(Weapon_Ref.reloadSounds[Random.Range(0, 6)]);
            }

            yield return new WaitForSeconds(reloadTime);

            
        }
        
        ReloadFinished();
    }
    
     
}  
