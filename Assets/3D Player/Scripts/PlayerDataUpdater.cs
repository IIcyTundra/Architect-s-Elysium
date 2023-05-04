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
    private Image UI_Sprite;
    private RectTransform HealthUI;
    public AudioSource PSounds;
    public Player_SO PSO_Ref;
    // Start is called before the first frame update
    private void Start()
    {
        PC_Ref = GetComponent<Player3D_Controller>();
        UI_Sprite = GameObject.Find("WeaponIcon").GetComponent<Image>();
        W_Sprite = GameObject.Find("GunHolder").GetComponentInChildren<SpriteRenderer>();
        HealthUI = GameObject.Find("HealthColor").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(PSO_Ref.Health);
        HealthUI.localScale = new Vector3(PSO_Ref.Health/100f,1,1);
        W_Sprite = GameObject.Find("GunHolder").GetComponentInChildren<SpriteRenderer>();
        UI_Sprite.sprite = W_Sprite.sprite;
        Death();
    }


    private void Death()
    {
        if(PSO_Ref.Health <= 0 && !PSounds.isPlaying)
        {
            PSounds.Play();
        }
    }
}

