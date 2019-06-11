using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true;
    Waypoint searchCenter; //the current search center


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

        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            print("Searching from: " + searchCenter); //todo remove log
            searchCenter.isExplored = true;
            HaltIfEnd();
            //explore neighbours
            ExploreNeighbours();

        }
        // todo work out path from start to end point
        print("finished pathfinding");
    }

    private void HaltIfEnd()
    {
        if (searchCenter == endPoint)
        {
            Debug.Log("Found end of the path"); //TODO remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if(!isRunning){ return; } 

        foreach (Vector2Int direction in directions)
        {
            //find neighbour coordinates
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch
            {
                
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        // find neighbour
        Waypoint neightbour = grid[neighbourCoordinates];
        if (neightbour.isExplored || queue.Contains(neightbour))
        {
            //do nothing
        }
        else
        {
            //change color of neighbour top
            
            //queue neighbour
            queue.Enqueue(neightbour);
            neightbour.exploredFrom = searchCenter;
            print("Queueing " + neightbour);
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
