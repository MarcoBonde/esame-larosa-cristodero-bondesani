using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public float speed;

    // Start is called before the first frame update
    void Update()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    
    void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Platform"))
            {
                Destroy(gameObject);
            }
    }
}
