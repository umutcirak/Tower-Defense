using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Node node;

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

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
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
