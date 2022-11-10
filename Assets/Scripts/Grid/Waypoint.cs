using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    void Awake()
    {
        LabelTag();
    }
   

    void OnMouseDown()
    {
        Debug.Log(transform.name);
    }


    void LabelTag()
    {
        if (transform.parent.name.Equals("Path"))
        {
            gameObject.tag = "Path";
        }
        else
        {
            gameObject.tag = "Grid";
        }
    }
}
