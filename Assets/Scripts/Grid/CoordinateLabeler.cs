using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [Header("Grid Color")]
    [SerializeField] Color defaultColor;
    [SerializeField] Color blockedColor;
    [SerializeField] Color exploredColor;
    [SerializeField] Color pathColor;


    private int gridLength;
    public int GridLength { get { return gridLength; } }
    TextMeshPro labelCoordinate;

    Vector2Int coordinates;

    GridManager gridManager;

    bool isLabeled;

   
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();

        labelCoordinate = GetComponent<TextMeshPro>();
        gridLength = (int)UnityEditor.EditorSnapSettings.move.x;
    }
    void Start()
    {
        GridSetup();
    }

    void Update()
    {
        if (!Application.isPlaying) { GridSetup(); }       
    }

    void GridSetup()
    {
        SetCoordinates();        
        UpdateName();      
        DisplayCoordinates();
        SetLabelColor();
    }

    void DisplayCoordinates()
    {
        
        labelCoordinate.text = (coordinates.x + "," + coordinates.y).ToString();
    }

    void SetCoordinates()
    {        
        Transform transformParent = GetComponentInParent<Transform>();
        coordinates = new Vector2Int((int) transformParent.position.x, 
            (int)transformParent.position.z) / gridLength;
                
    }

    // FOR DEBUGGING PATHFINDING
    void SetLabelColor()
    {       
        if(gridManager == null) { return; }
        if(!gridManager.Grid.ContainsKey(coordinates)) { return; }

        Node node = gridManager.Grid[coordinates];

        if      (!node.isWalkable) { labelCoordinate.color = blockedColor; }
        else if (node.isPath)      { labelCoordinate.color = pathColor;    }
        else if (node.isExplored)  { labelCoordinate.color = exploredColor;}
        else                       { labelCoordinate.color = defaultColor; }

    }
    

    void UpdateName()
    {
        transform.parent.name = "Tile (" + coordinates.x + "," + coordinates.y + ")";
    }
}
