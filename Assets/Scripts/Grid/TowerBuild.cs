using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] GameObject tower;   
    [SerializeField] float yPos;

    JPMorgan bank;
    Waypoint waypoint;
    Pathfinder pathfinder;
    GridManager gridManager;

    private Vector3 position;
    


    private void Awake()
    {
        bank = FindObjectOfType<JPMorgan>();
        waypoint = GetComponent<Waypoint>();
        pathfinder = FindObjectOfType<Pathfinder>();
        gridManager = FindObjectOfType<GridManager>();
    }    

    void Start()
    {
        position = new Vector3(transform.position.x, yPos, transform.position.z);        
    }
    void OnMouseDown()
    {
        if (waypoint.freeArea && !waypoint.hasTower)
        {
            int cost = tower.GetComponent<Tower>().cost;
            if (cost > bank.Balance) { return; }
            Vector2Int coordinates = waypoint.gridPos;            
            if (pathfinder.WillBlockThePath(coordinates)) { return; }

            if (BuildTower())
            {
                gridManager.BlockTheNode(coordinates);
                pathfinder.GetPath(); // LAST
            }                      
                       
        }
            
    }

    bool BuildTower()
    {
        int cost = tower.GetComponent<Tower>().cost;
        if (cost > bank.Balance) { return false; }

        GameObject newTower = Instantiate(tower, position, Quaternion.identity);
        newTower.transform.parent = GameObject.Find("Towers").transform;
        newTower.name = (newTower.name + " " + transform.position.x + ", " + transform.position.z);

        bank.DecreaseBalanceByTower(cost);

        waypoint.hasTower = true;

        return true;

    }






}
