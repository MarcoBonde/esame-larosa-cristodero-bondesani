using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybulletinteraction : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Update()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }


    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    { 

        RaycastHit2D hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1000))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left), Color.black);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * 1000, Color.red);
            Debug.Log("Did not Hit");
        }
    }

// Update is called once per frame

void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

    // Float a rigidbody object a set distance above a surface.

    







