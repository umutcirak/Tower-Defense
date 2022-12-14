using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startPos;
    [SerializeField] Vector2Int destinationPos;

    Node startNode;
    Node destinationNode;
    Node currentNode;

    Queue<Node> queue = new Queue<Node>();
    Dictionary<Vector2Int, Node> searchedNodes = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    // TRAVERSE PRIORITY

    GridManager gridManager;    
    
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();        

    }

    void Start()
    {
        startNode = gridManager.Grid[startPos];
        destinationNode = gridManager.Grid[destinationPos];
                
        GetPath();               
    }
    

    public List<Node> GetPath()
    {
        gridManager.ResetGrid();
        BreadthFirstSearch();
        return BuildPath();
    }
      


    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborPos = currentNode.position + direction;

            if (gridManager.Grid.ContainsKey(neighborPos))
            {                
                neighbors.Add(gridManager.Grid[neighborPos]);
            }
        }

        foreach (Node neighbor in neighbors)
        {
            //gridManager.BlockNode(neighbor.position);

            if(!searchedNodes.ContainsKey(neighbor.position) && neighbor.isWalkable)
            {
                neighbor.parent = currentNode;
                searchedNodes.Add(neighbor.position, neighbor);
                queue.Enqueue(neighbor);
            }


        }
    }

    void BreadthFirstSearch()
    {
        queue.Clear();
        searchedNodes.Clear();


        bool isRunning = true;
        queue.Enqueue(startNode);
        searchedNodes.Add(startNode.position, startNode);

        while(isRunning && queue.Count > 0)
        {
            currentNode = queue.Dequeue();
            currentNode.isExplored = true;
            ExploreNeighbors();

            if(currentNode.position == destinationNode.position)
            {
                isRunning = false;
            }
        }
    }

    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();

        Node current = gridManager.Grid[destinationPos];
        path.Add(current);
        current.isPath = true;

        while(current.parent != null)
        {
            current = current.parent;
            path.Add(current);
            current.isPath = true;
        }

        path.Reverse();

        return path;
    }

    public bool WillBlockThePath(Vector2Int coordinates)
    {
        if(gridManager.Grid.ContainsKey(coordinates))
        {
            bool previousState = gridManager.Grid[coordinates].isWalkable;

            gridManager.Grid[coordinates].isWalkable = false;
            List<Node> newPath = GetPath();
            gridManager.Grid[coordinates].isWalkable = previousState;

            int minPathLength = Mathf.Abs(destinationPos.x - startPos.x) + Mathf.Abs(destinationPos.y - startPos.y);

            if(newPath.Count <= minPathLength)
            {
                GetPath(); // Path changed to calculate blocking node, set previous back
                return true;
            }

        }

        return false;
    }

    


}
