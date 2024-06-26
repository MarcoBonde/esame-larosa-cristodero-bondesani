﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public AudioSource gunshotSound;

    Rigidbody2D _rigidbody;
    public float speed;
    public PolygonCollider2D collide;
    public SpriteRenderer sprite;
    //private float thrust = 10.0f;
    //public float x, y, z;
    public GameObject speeder;

    // Start is called before the first frame update

    void Start()
    {
        speeder = GameObject.FindGameObjectWithTag("speedometer");
        gunshotSound = GetComponent<AudioSource>();
        gunshotSound.Play();
    }
    void Update()
    {
        speed = -speeder.GetComponent<speedometer>().speedBullet;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(speed, 0);
        //transform.position = new Vector3(5.0f, -2.0f, 0.0f);
        //_rigidbody.AddForce(transform.up * thrust, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Enemy")
            || collision.gameObject.CompareTag("GunBullet") || collision.gameObject.CompareTag("SniperBullet") || collision.gameObject.CompareTag("RocketBullet"))
            {


            StartCoroutine(DestroyMe());

        }
    }
    IEnumerator DestroyMe()
    {
        collide.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}



