using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunizioniSFX : MonoBehaviour

{

    public AudioSource MunizioniSound;


    // Start is called before the first frame update
    void Start()
    {

        MunizioniSound = GetComponent <AudioSource>();

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MunizioniSound.Play();
        }


    }
}