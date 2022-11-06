using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] GameObject tower;
    [SerializeField] bool freeArea;
    [SerializeField] float yPos;
    
    private Vector3 position;
    private bool hasTower;

    private void Start()
    {
        position = new Vector3(transform.position.x, yPos, transform.position.z);
        hasTower = false;       
    }
    void OnMouseDown()
    {
        if (freeArea && !hasTower)
        {
            GameObject newTower = GameObject.Instantiate(tower, position, Quaternion.identity);
            newTower.transform.parent = GameObject.Find("Towers").transform;
            newTower.name = ( newTower.name + " " + transform.position.x + ", " + transform.position.z);
            hasTower = true;
        }        
    }



}
