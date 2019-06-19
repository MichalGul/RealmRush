using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathParticleSystem;
    [SerializeField] AudioClip enemyDamageSFX;
    [SerializeField] AudioClip enemyDeathSFX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other) 
    {
        //print("I am hit");    
        ProcessHit();

        if(hitPoints <= 0)
        {
            KillEnemy(deathParticleSystem);
        }
    }

    public void KillEnemy(ParticleSystem deathParticles)
    {
        var deathParticle = Instantiate(deathParticles, transform.position, Quaternion.identity);
        deathParticle.Play();
        Destroy(deathParticle.gameObject, deathParticle.main.duration);

        //AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);

        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlesPrefab.Play();
        GetComponent<AudioSource>().PlayOneShot(enemyDamageSFX);
        //print("current hit points: " + hitPoints);
        
    }




}
