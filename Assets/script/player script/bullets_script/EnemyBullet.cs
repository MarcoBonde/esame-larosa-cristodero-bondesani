using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float speed;
    //private float thrust = 10.0f;
    //public float x, y, z;

    // Start is called before the first frame update
    void Update()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(speed, 0);
        //transform.position = new Vector3(5.0f, -2.0f, 0.0f);
        //_rigidbody.AddForce(transform.up * thrust, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
    }
}



