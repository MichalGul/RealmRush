using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] public Waypoint startPoint;
    [SerializeField] public Waypoint endPoint;

    // Start is called before the first frame update
    void Start()
    {
        ColorStartAndEnd();
        LoadBlocks();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>(); //Find everything in scene that is Waypoint (dont have to be child of this GO)
        foreach (Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverlapping)
            {
                Debug.Log("Skipping overlapping block: " + waypoint);
            }
            else
            {
                //Add to dict
                grid.Add(waypoint.GetGridPos(), waypoint);
                
            }
            

        }
        print("Loaded " + grid.Count + " blocks");
    }



    public void ColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);
    }

}
