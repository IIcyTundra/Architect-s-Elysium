using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Controller : MonoBehaviour
{
    Vector3 mousePos;
    public CircleCollider2D range;
    public SpriteRenderer cursor;
    public Camera pCam;
    Vector3 minRangeBounds;
    Vector3 maxRangeBounds;

    void Start()
    {
        cursor = GetComponent<SpriteRenderer>();
        cursor.sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        minRangeBounds = range.bounds.min;
        maxRangeBounds = range.bounds.max;
        mousePos = pCam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        float clampedX = Mathf.Clamp(transform.position.x, range.radius + 3, maxRangeBounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, minRangeBounds.y + 3, maxRangeBounds.y);
        
    
        transform.position = new Vector3(clampedX,clampedY);
        //Debug.Log(transform.position);
    }

}
