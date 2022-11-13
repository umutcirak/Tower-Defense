using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] GameObject tower;   
    [SerializeField] float yPos;

    JPMorgan bank;
    Waypoint waypoint;
   
    private void Awake()
    {
        bank = FindObjectOfType<JPMorgan>();
        waypoint = GetComponent<Waypoint>();
   
    }

    private Vector3 position;
    private bool hasTower;

    private void Start()
    {
        position = new Vector3(transform.position.x, yPos, transform.position.z);
        hasTower = false;       
    }
    void OnMouseDown()
    {
        if (waypoint.freeArea && !hasTower)
        {
            int cost = tower.GetComponent<Tower>().cost;            
            if(cost > bank.Balance) { return; }

            GameObject newTower = GameObject.Instantiate(tower, position, Quaternion.identity);
            newTower.transform.parent = GameObject.Find("Towers").transform;
            newTower.name = ( newTower.name + " " + transform.position.x + ", " + transform.position.z);
                        
            bank.DecreaseBalanceByTower(cost);

            hasTower = true;
           
        }        
    }



}
