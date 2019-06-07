using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dzięki temu skrypt będzie się odpalał w edytorze 
[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;


    private void Awake() 
    {
        waypoint = GetComponent<Waypoint>();
    }
    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        // Snap block to 10/10/10 grid
        SnapToGrid();
        UpdateLabel();

    }

    private void UpdateLabel()
    {
        float gridSize = waypoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();

        textMesh.text = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
        transform.position = new Vector3(waypoint.GetGridPos().x, 0, waypoint.GetGridPos().y);
        gameObject.name = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
    }

    private void SnapToGrid()
    {
        float gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
                                        waypoint.GetGridPos().x, 
                                        0, 
                                        waypoint.GetGridPos().y);
    }
}
