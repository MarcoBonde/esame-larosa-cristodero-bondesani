using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public Vector3 ShootOffset;
    public Transform ShootSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //Length of the ray
        float laserLength = 50f;
        Vector2 startPosition = ShootSpawner.position;
        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.left, laserLength);

        //If the collider of the object hit is not NUll
        if (hit.collider != null)
        {
            hit.collider.tag == "Player"

            //Hit something, print the tag of the object
            Debug.Log("Hitting: " + hit.collider.tag);
            //Get the sprite renderer component of the object
            SpriteRenderer sprite = hit.collider.gameObject.GetComponent<SpriteRenderer>();
            //Change the sprite color
            sprite.color = Color.green;


            //Method to draw the ray in scene for debug purpose
            Debug.DrawRay(startPosition, -transform.right * hit.distance, Color.green);
        }
        else
        {
            //Method to draw the ray in scene for debug purpose
            Debug.DrawRay(startPosition, -transform.right * laserLength, Color.red);
        }
        

    }
}
