using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Range(0.1f, 120f)][SerializeField] float secondsBetweenSpawns = 4;
    [SerializeField] EnemyMovement enemyToSpawn;
    [SerializeField] float numberOfEnemiesToSpawn;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity, transform);
            print("Spawning");
            yield return new WaitForSeconds(secondsBetweenSpawns); //return execution 
        }
        
    }

}
