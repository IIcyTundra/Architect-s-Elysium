using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    Camera PCam;
    Canvas PCanvas;
    // Start is called before the first frame update
    void Start()
    {
       PCam = GameObject.Find("PlayerCam").GetComponent<Camera>();
       PCanvas = GetComponent<Canvas>();
       PCanvas.worldCamera = PCam;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
