using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Vector2Int position;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node parent;
    public Node(Vector2Int position, bool isWalkable)
    {
        this.position = position;
        this.isWalkable = isWalkable;
        this.isExplored = false;
        this.isPath = false;
        this.parent = null;
    }

    
}
