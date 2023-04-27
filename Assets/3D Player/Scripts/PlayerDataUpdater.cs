using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerDataUpdater : MonoBehaviour
{
    private Player3D_Controller PC_Ref;
    private Weapon_Function_Handler UI_Ref;
    private SpriteRenderer W_Sprite;
    private TextMeshProUGUI PlayerInfo;
    private Image UI_Sprite;
    // Start is called before the first frame update
    private void Start()
    {
        PC_Ref = GetComponent<Player3D_Controller>();
        UI_Sprite = GameObject.Find("WeaponIcon").GetComponent<Image>();
        W_Sprite = GameObject.Find("GunHolder").GetComponentInChildren<SpriteRenderer>();
        //PlayerInfo = GameObject.Find("PlayerHealth").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update()
    {
        W_Sprite = GameObject.Find("GunHolder").GetComponentInChildren<SpriteRenderer>();
        UI_Sprite.sprite = W_Sprite.sprite;
        Death();
        //PlayerInfo.SetText(PC_Ref.CurrHealth + "/" + PC_Ref.PlayerDataRef.Health);
    }


    private void Death()
    {
        if(PC_Ref.CurrHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.CompareTag("Bullet"))
        {
            PC_Ref.CurrHealth -= 5;
        }
    }
}

