﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{

    public Transform ShootSpawner;
    public Transform bullet_type;
    public float laserLength = 50f;
    private bool reloading;
    private float secondiRicarica;
    public GameObject exclamation;

    // Start is called before the first frame update
    void Start()
    {
        reloading = false;
        secondiRicarica = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool getRealoading() {
        return reloading;
    }
    public void setRealoding(bool devoRicaricare) {
        if (devoRicaricare)
        {
            reloading = devoRicaricare;
            StartCoroutine(reload());
        }
        else {
            reloading = false;
        }
    }
    void FixedUpdate()
    {
        //Length of the ray
        Vector2 startPosition = ShootSpawner.position;
        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.left, laserLength);

        //If the collider of the object hit is not NUll
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player" && (!reloading))
            {
                StartCoroutine(shoot());
            }

            //Hit something, print the tag of the object
            //Debug.Log("Hitting: " + hit.collider.tag);
            //Get the sprite renderer component of the object
            //SpriteRenderer sprite = hit.collider.gameObject.GetComponent<SpriteRenderer>();
            //Change the sprite color
            //sprite.color = Color.green;


            //Method to draw the ray in scene for debug purpose
            Debug.DrawRay(startPosition, -transform.right * hit.distance, Color.green);
        }
        else
        {
            //Method to draw the ray in scene for debug purpose
            Debug.DrawRay(startPosition, -transform.right * laserLength, Color.red);
        }
        

    }
    IEnumerator reload() {
        yield return new WaitForSeconds(secondiRicarica);
        setRealoding(false);
    }
    IEnumerator shoot() {

        setRealoding(true);
        yield return new WaitForSeconds(0.1f);
        exclamation.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet_type, ShootSpawner.position, ShootSpawner.rotation);
        yield return new WaitForSeconds(0.6f);
        exclamation.SetActive(false);

    }
}
