using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    private int gridSize;
    TextMeshPro labelCoordinate;

    Vector2Int coordinates;


    void Start()
    {
        GridSetup();
    }
    void Awake()
    {
        labelCoordinate = GetComponent<TextMeshPro>();
        gridSize = (int)UnityEditor.EditorSnapSettings.move.x;
    }

    void Update()
    {
        if (!Application.isPlaying) { GridSetup(); }       
    }

    void GridSetup()
    {
        SetCoordinates();
        DisplayCoordinates();
        UpdateName();
    }

    void DisplayCoordinates()
    {
        labelCoordinate.text = (coordinates.x + "," + coordinates.y).ToString();
    }

    void SetCoordinates()
    {        
        Transform transformParent = GetComponentInParent<Transform>();
        coordinates = new Vector2Int((int) transformParent.position.x, 
            (int)transformParent.position.z) / gridSize;
                
    }


    void UpdateName()
    {
        transform.parent.name = "Tile (" + coordinates.x + "," + coordinates.y + ")";
    }
}
