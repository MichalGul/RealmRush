using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] Color exploredColor;
    [SerializeField] Color unexploredColor;


    public bool isExplored = false;
    public Waypoint exploredFrom;

    const int GRID_SIZE = 10;

    Vector2Int gridPos;




    public int GetGridSize()
    {
        return GRID_SIZE;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / GRID_SIZE) ,
            Mathf.RoundToInt(transform.position.z / GRID_SIZE)
        );
    }

    public void SetTopColor(Color color)
    {
        try
        {
            MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
            if(topMeshRenderer)
            {
                topMeshRenderer.material.color = color;
            }
        }
        catch
        {
            //Debug.Log("Not colored Top");
        }
    }



    // Update is called once per frame
    void Update()
    {
        if(isExplored)
        {
            SetTopColor(exploredColor); //todo move later
        }
        else
        {
            SetTopColor(unexploredColor);           
        }
    }
}
