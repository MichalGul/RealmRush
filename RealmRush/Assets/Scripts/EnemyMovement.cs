using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
//     //[SerializeField] List<Waypoint> path = new List<Waypoint>();

//     // Start is called before the first frame update
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

//Coorutine
    IEnumerator  FollowPath(List<Waypoint> path)
    {
        Debug.Log("Start patrol...");
        foreach (var item in path)
        {
            transform.position = item.transform.position;
            //print("Visiting: " + item.name);
            // wait a second
            yield return new WaitForSeconds(2f); //return execution 
        }
        print("Ending patrol");
    }
}
