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
        _rigidbody.velocity = new Vector2(-50, 0);
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
