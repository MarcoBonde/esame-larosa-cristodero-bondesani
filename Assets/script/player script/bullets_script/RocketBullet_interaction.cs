using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet_interaction : MonoBehaviour

{
    Rigidbody2D _rigidbody;
    public PolygonCollider2D collide;
    public SpriteRenderer sprite;

    public AudioSource gunshotSound;

    void Start()
    {

        gunshotSound = GetComponent<AudioSource>();

        gunshotSound.Play();

    }

    // Start is called before the first frame update
    void Update()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(50, 0);
    }

    // Update is called once per frame
    
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Enemy1") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Enemy") 
            || collision.gameObject.CompareTag("Enemy3") || collision.gameObject.CompareTag("Enemy2"))
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
