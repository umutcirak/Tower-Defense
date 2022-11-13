using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{   

    [SerializeField] Vector2Int gridSize;

    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }

    Waypoint[] waypoints;


    void Awake()
    {       
        PopulateGrid();
        BlockNodes();
    }


    void PopulateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y= 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grid.Add(coordinates, new Node(coordinates, true));

            }
        }
    }
        

    public void BlockNodes()
    {
        waypoints = FindObjectsOfType<Waypoint>();
        int gridLength = (int)UnityEditor.EditorSnapSettings.move.x;

        foreach (Waypoint waypoint in waypoints)
        {
            if(waypoint.freeArea) { continue; }

            int posX = Mathf.RoundToInt(waypoint.transform.position.x / gridLength);
            int posZ = Mathf.RoundToInt(waypoint.transform.position.z / gridLength);
            Vector2Int gridPos = new Vector2Int(posX, posZ);

            if (grid.ContainsKey(gridPos))
            {
                Debug.Log(gridPos + " is blocked.");
                grid[gridPos].isWalkable = false;
            }
            else
            {
                Debug.Log("There is no tile in pos:" + gridPos);
            }
        }

       

       
    }




}
