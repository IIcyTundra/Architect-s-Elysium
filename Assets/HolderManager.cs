using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderManager : MonoBehaviour
{
    public Transform orientation;
    public Player3D_Cam CamRef;

    // Update is called once per frame
    void Update()
    {
        // CamRef.xRotation = Mathf.Clamp(CamRef.xRotation, -90f, 90f);
        // transform.rotation = Quaternion.Euler(CamRef.xRotation,CamRef.yRotation, 0);
        // orientation.rotation = Quaternion.Euler(0, CamRef.yRotation, 0);
    }
}
