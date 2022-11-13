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

        BreadthFirstSearch();
        BuildPath();

        //AgaNedenOlmuyor();
    }
       
    void AgaNedenOlmuyor()
    {
        List<Vector2Int> poses = new List<Vector2Int>();
        Vector2Int pos1 = new Vector2Int(0, 3);
        poses.Add(pos1);
        Vector2Int pos2 = new Vector2Int(1, 3);
        poses.Add(pos2);
        Vector2Int pos3 = new Vector2Int(2, 3);
        poses.Add(pos3);
        Vector2Int pos4 = new Vector2Int(3, 3);
        poses.Add(pos4);

        foreach (Vector2Int pos in poses)
        {
            Debug.Log(pos);
            Debug.Log("Explored: " + gridManager.Grid[pos].isExplored);
            Debug.Log("Walkable: " + gridManager.Grid[pos].isWalkable);
            Debug.Log("Path: " +     gridManager.Grid[pos].isPath);

        }


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

    


}
