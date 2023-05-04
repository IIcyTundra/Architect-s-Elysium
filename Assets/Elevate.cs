using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevate : MonoBehaviour
{
    public bool CanMove;

    [SerializeField] float Speed;
    [SerializeField] int StartP;
    [SerializeField] Transform[] points;   

    int i;
    bool reverse;


    void Start()
    {
        transform.position = points[StartP].position;
        i = StartP;
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, points[i].position) < 0.1f)
        {
            CanMove = true;

            if(i == points.Length -1)
            {
                reverse = true;
                i--;
                return;
            } else if(i == 0)
            {
                reverse = true;
                i++;
                return;
            }


            if (reverse)
            {
                i--;
            }
        }


        if(CanMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, Speed * Time.deltaTime);
        }
    }

}
