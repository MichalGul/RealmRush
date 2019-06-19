using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int basehealth = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip damageSFX;


    private void Start() 
    {
        healthText.text = basehealth.ToString();    

    }
    private void OnTriggerEnter(Collider other) 
    {

        basehealth -= healthDecrease;
        GetComponent<AudioSource>().PlayOneShot(damageSFX);
        healthText.text = basehealth.ToString();

    }
}
