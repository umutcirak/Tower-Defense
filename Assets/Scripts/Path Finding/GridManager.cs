using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] float enemyHeight = 4.5f;
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

    public void ResetGrid()
    {
        foreach (KeyValuePair<Vector2Int,Node> item in grid)
        {
            item.Value.isExplored = false;
            item.Value.isPath = false;
            item.Value.parent = null;           
        }
    }

    
    void BlockTheNode(Vector2Int gridPos)
    {
        if(!grid.ContainsKey(gridPos)) { return; }

        grid[gridPos].isWalkable = false;
    }
    

    public void BlockNodes()
    {
        waypoints = FindObjectsOfType<Waypoint>();        

        foreach (Waypoint waypoint in waypoints)
        {
            if(waypoint.freeArea) { continue; }
                       
            Vector2Int gridPos = WorldPosToGridPos(waypoint.transform.position);

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


    public Vector3 GridPosToWorldPos(Vector2Int gridPos)
    {
        int gridLength = (int)UnityEditor.EditorSnapSettings.move.x;
                
        float posX = gridPos.x * gridLength;
        float posZ = gridPos.y * gridLength;

        Vector3 worldPos = new Vector3(posX, enemyHeight, posZ);

        return worldPos;
    }



    public Vector2Int WorldPosToGridPos(Vector3 waypointPos)
    {
        int gridLength = (int)UnityEditor.EditorSnapSettings.move.x;

        int posX = Mathf.RoundToInt(waypointPos.x / gridLength);
        int posZ = Mathf.RoundToInt(waypointPos.z / gridLength);

        Vector2Int gridPos = new Vector2Int(posX, posZ);

        return gridPos;
    }




}
