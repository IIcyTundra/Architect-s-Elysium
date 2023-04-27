using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DL_Handler : MonoBehaviour
{
    public Weapon_SO W_Ref;
    public Rigidbody PlayerRb;
    public Camera PlayerCam;
    public Transform GunDir;
    bool RTS, reloading; //Checks if we're ready to shoot
    int BulletsLeft, BulletsShot, CurrAmmo, CurrReserves; 
    public bool allowInvoke = true;
    bool shooting;
    private TextMeshProUGUI PlayerInfo;
    
    private void Awake()
    {
        PlayerCam = GameObject.Find("PlayerCam").GetComponent<Camera>();
        GunDir = GameObject.Find("GunDir").GetComponent<Transform>();
        PlayerRb = GetComponentInParent<Rigidbody>();
        PlayerInfo = GameObject.Find("Ammo Text").GetComponent<TextMeshProUGUI>();

        CurrReserves = W_Ref.W_Ammo_Capacity;
        RTS = true;
    }

    private void Update()
    {
        MyInput();
        PlayerInfo.SetText(BulletsLeft/W_Ref.W_BPT + "/" + W_Ref.W_Ammo_Mag/W_Ref.W_BPT);
    }

    private void MyInput()
    {
        //Check if allowed to hold down button and take corresponding input
        if (W_Ref.FullAutoToggle) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Reloading 
        if (Input.GetKeyDown(KeyCode.R) && BulletsLeft < CurrAmmo && !reloading) Reload();

        //Reload automatically when trying to shoot without ammo
        if (RTS && shooting && !reloading && BulletsLeft <= 0 && CurrReserves != 0) Reload();

        //Shooting
        if (RTS && shooting && !reloading && BulletsLeft > 0)
        {
            //Set bullets shot to 0
            BulletsShot = 0;

            Shoot();
            Debug.Log("Shot Fired");
        }
    }

    private void Shoot()
    {
        
        RTS = false;

        //Find the exact hit position using a raycast
        Vector2 MPos = Input.mousePosition;
        Ray ray = PlayerCam.ViewportPointToRay(MPos); //Just a ray through the middle of your current view
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the player

        //Calculate direction from GunDir to targetPoint
        Vector3 directionWithoutSpread = targetPoint - GunDir.position;

        //Calculate W_Ref.W_Spread
        float x = Random.Range(-W_Ref.W_Spread, W_Ref.W_Spread);
        float y = Random.Range(-W_Ref.W_Spread, W_Ref.W_Spread);
        float z = Random.Range(-W_Ref.W_Spread, W_Ref.W_Spread);
        

        //Calculate new direction with W_Ref.W_Spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, z); //Just add W_Ref.W_Spread to last direction

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(W_Ref.W_Bullet, GunDir.position, Quaternion.identity); //store instantiated bullet in currentBullet
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * W_Ref.ShootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(PlayerCam.transform.up * W_Ref.UpwardForce, ForceMode.Impulse);

        //Instantiate muzzle flash, if you have one
        if (W_Ref.MuzzleFlash != null)
            Instantiate(W_Ref.MuzzleFlash, GunDir.position, Quaternion.identity);

        BulletsLeft--;
        BulletsShot++;

        //Invoke resetShot function (if not already invoked), with your timeBetweenShooting
        if (allowInvoke)
        {
            Invoke("ResetShot", W_Ref.W_TBShooting);
            allowInvoke = false;

            //Add recoil to player (should only be called once)
            PlayerRb.AddForce(-directionWithSpread.normalized * W_Ref.RecoilForce, ForceMode.Impulse);
        }

        //if more than one bulletsPerTap make sure to repeat shoot function
        if (BulletsShot < W_Ref.W_BPT && BulletsLeft > 0)
            Invoke("Shoot", W_Ref.W_TBShots);
    }
    private void ResetShot()
    {
        //Allow shooting and invoking again
        RTS = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", W_Ref.W_Reload_Speed); //Invoke ReloadFinished function with your reloadTime as delay
    }
    private void ReloadFinished()
    {
        //Fill magazine
        CurrReserves -= W_Ref.W_Ammo_Mag - BulletsLeft;
        BulletsLeft = W_Ref.W_Ammo_Mag;
        reloading = false;
    }
}
