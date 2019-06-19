using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    [Range(0.1f, 120f)][SerializeField] float secondsBetweenSpawns = 4;
    [SerializeField] EnemyMovement enemyToSpawn;
    [SerializeField] float numberOfEnemiesToSpawn;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip spawnSFX;
    int score;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnEnemies());
        spawnedEnemies.text = score.ToString();
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
            GetComponent<AudioSource>().PlayOneShot(spawnSFX);
            UpdateScore();
            yield return new WaitForSeconds(secondsBetweenSpawns); //return execution 
        }

    }

    private void UpdateScore()
    {
        score += 1;
        spawnedEnemies.text = score.ToString();
    }
}
