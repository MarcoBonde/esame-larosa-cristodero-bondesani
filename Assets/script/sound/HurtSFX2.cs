using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSFX2 : MonoBehaviour
{

    public AudioSource hurtSound;


    // Start is called before the first frame update
    void Start()
    {

        hurtSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("SniperBullet") || collision.gameObject.CompareTag("RocketBullet"))
        {
            hurtSound.Play();
        }


    }
}