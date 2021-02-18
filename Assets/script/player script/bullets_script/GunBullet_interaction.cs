using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet_interaction : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float speed = 50;
    public PolygonCollider2D collide;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Update()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Enemy1") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("enemybullet"))
            {
            StartCoroutine(DestroyMe());
            }
        if (collision.gameObject.CompareTag("Enemy2") || collision.gameObject.CompareTag("Enemy3"))
        {
            speed = 0;
            _rigidbody.gravityScale = 10;
            StartCoroutine(DestroyMe2());
        }

    }

    IEnumerator DestroyMe()
    {
        collide.enabled = false;
        sprite.enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    IEnumerator DestroyMe2()
    {
        collide.enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
