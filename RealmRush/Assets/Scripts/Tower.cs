using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30;
    [SerializeField] ParticleSystem projectileParticle;

    public Waypoint baseWaypoint; //what the tower is standing on

    //state
    Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();

        if (targetEnemy)
        {
            LookAtEnemt();
            FireAtEnemy();
        }
        else
        {
            Shoot(false);       
        }
    }

    private void SetTargetEnemy()
    {
        //Get the collection of things
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length == 0) { return; }

        //Assume the first is the winner
        Transform closestEnemy = sceneEnemies[0].transform; 

        //for each item in collection
        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
            
        }
        //Update winner
        targetEnemy = closestEnemy;
      
    }

    private Transform GetClosest(Transform closestEnemy, Transform otherEnemy)
    {
        if(Vector3.Distance(transform.position, closestEnemy.position) < Vector3.Distance(transform.position, otherEnemy.position))
        {
            return closestEnemy;
        }
        else
        {
            return otherEnemy;
        }
    }

    private void FireAtEnemy()
    {
       float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, transform.position);

       if (distanceToEnemy <= attackRange)
       {
           Shoot(true);
       }
       else
       {
           Shoot(false);
       }
    }

    private void Shoot(bool isActive)
    {
        var emmisionModule = projectileParticle.emission;
        emmisionModule.enabled = isActive;
    }

    public void LookAtEnemt()
    {
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
        }
    }

    private void OnDrawGizmosSelected()       
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


}
