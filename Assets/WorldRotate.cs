using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotate : MonoBehaviour
{
    public float RotateSpeed;

    // Update is called once per frame
    
    void Update()
    {
        transform.Rotate(0f,RotateSpeed * Time.deltaTime, 0f);
    }
}
