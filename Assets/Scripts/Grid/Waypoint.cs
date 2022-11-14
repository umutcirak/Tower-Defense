using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool freeArea;
    public bool hasTower;

    private Vector2Int gridPos;

    GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
    }
    void Start()
    {
        hasTower = false;
        gridPos = gridManager.WorldPosToGridPos(transform.position);
    }


    void OnMouseDown()
    {
        DebugNode();
    }

    void DebugNode()
    {
        Vector2Int gridPos = gridManager.WorldPosToGridPos(transform.position);
        Node node = gridManager.Grid[gridPos];

        Debug.Log("Node Pos:" + gridPos + ", Is Explored: " +
            node.isExplored + ", Is Walkable: " + node.isWalkable + ", Is Path: " + node.isPath);
    }







}
