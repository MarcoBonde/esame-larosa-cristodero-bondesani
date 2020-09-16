using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammodestroyer : MonoBehaviour
{
    public Vector3 impulseMagnitude = new Vector3(5.0f, 3.0f, 0.0f);
    public AudioSource Munizioni;
    
    // Start is called before the first frame update
    void Start()
    {
        
        GetComponent<Rigidbody2D>().AddForce(impulseMagnitude, ForceMode2D.Impulse);
        Munizioni = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Munizioni.Play();
        }


    }
}

