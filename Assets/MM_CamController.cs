using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM_CamController : MonoBehaviour
{
    [HideInInspector] public bool Settings;

    Animator CamAnimate;

    void Start()
    {
        CamAnimate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CamAnimate.SetBool(name: "SettingClicked", Settings);
    }
}
