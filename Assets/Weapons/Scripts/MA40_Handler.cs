using UnityEngine;
using TMPro;

public class MA40_Handler : MonoBehaviour
{
    public Weapon_SO Weapon_Ref;
    RaycastHit RayHit;
    public AudioSource audioSource;
    int bulletsLeft, bulletsShot;
    //bools 
    bool shooting, readyToShoot, reloading, allowInvoke;
    //Reference
    public LayerMask Enemy;
    public GameObject Weapon_AP;
    //public ParticleSystem MuzzleFlash;
    public Camera PlayerCam;
    public TextMeshProUGUI Ammo_Display;   


    private void Awake()
    {
        bulletsLeft = Weapon_Ref.Weapon_Ammo_Mag;
        readyToShoot = true;

        audioSource.loop = false;
        audioSource.playOnAwake = true;
    }
    
    private void Update()
    {
        MyInput();
        

        //SetText
        Ammo_Display.SetText(bulletsLeft + "/" + Weapon_Ref.Weapon_Ammo_Mag);
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

        if (allowInvoke)
        {
            Invoke("ResetShot", Weapon_Ref.Weapon_TBShooting);
            allowInvoke = false;
        }

        //Debug.DrawRay(Weapon_Ref.PlayerCam.transform.position, Weapon_Ref.PlayerCam.transform.forward * Weapon_Ref.Weapon_Range, Color.green);
        readyToShoot = false;

        Ray ray = PlayerCam.ViewportPointToRay(new Vector3(0.5f,0.5f, 0));

        //Spread
        float x = Random.Range(-Weapon_Ref.Weapon_Spread, Weapon_Ref.Weapon_Spread);
        float y = Random.Range(-Weapon_Ref.Weapon_Spread, Weapon_Ref.Weapon_Spread);

        //RayCast
        if (Physics.Raycast(ray, out RayHit, Weapon_Ref.Weapon_Range))
        {
            
        }

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", Weapon_Ref.Weapon_TBShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", Weapon_Ref.Weapon_TBShots);
    }

    public void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
    public void Reload()
    {
        audioSource.clip = Weapon_Ref.reloadSounds[Random.Range(0, Weapon_Ref.reloadSounds.Length)];
        audioSource.Play();
        reloading = true;
        Invoke("ReloadFinished", Weapon_Ref.Weapon_Reload_Speed);
    }
    private void ReloadFinished()
    {
        bulletsLeft = Weapon_Ref.Weapon_Ammo_Mag;
        reloading = false;
    }
    
     
}  
