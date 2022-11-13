using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{   

    [SerializeField] Vector2Int gridSize;

    private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }



    void Awake()
    {
        PopulateGrid();
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

    Node GetNode(Vector2Int position)
    {
        if (grid.ContainsKey(position))
        {
            return grid[position];
        }
        else
        {
            return null;
        }
    }



   
}
