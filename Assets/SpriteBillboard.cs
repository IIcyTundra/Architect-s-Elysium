using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{

    Vector3 camdir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camdir = GameObject.Find("PlayerCam").transform.forward;
        camdir.y = 0;

        transform.rotation = Quaternion.LookRotation(camdir);
    }
}
