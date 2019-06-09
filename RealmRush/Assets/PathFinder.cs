using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true;
    Vector2Int[] directions =
    {
            Vector2Int.up,
            Vector2Int.right,
            Vector2Int.down,
            Vector2Int.left
    };

    [SerializeField] public Waypoint startPoint;
    [SerializeField] public Waypoint endPoint;

    // Start is called before the first frame update
    void Start()
    {
        ColorStartAndEnd();
        LoadBlocks();
        PathFind();
        //ExploreNeighbours();

    }

    private void PathFind()
    {
        queue.Enqueue(startPoint);

        while(queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            HaltIfEnd(searchCenter);

        }
        print("finished pathfinding");
    }

    private void HaltIfEnd(Waypoint waypoint)
    {
        if (waypoint == endPoint)
        {
            Debug.Log("Found end of the path"); //TODO remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinate = startPoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoordinate].SetTopColor(Color.blue);
            }
            catch
            {
                
            }
        }
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
