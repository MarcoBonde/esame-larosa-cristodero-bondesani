using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{// Stores a reference of the Rigidbody2D component (if any)
    Rigidbody2D _rigidbody;
    public float jumpMultiplier = 10;
    bool _isJumping;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }
private void Update()
    {
        if (Input.GetButtonDown("Jump") && !_isJumping)
        {
            _isJumping = true;

            Vector2 jumpForce = Vector2.up * jumpMultiplier;

            _rigidbody.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _isJumping = false;
        }

        if (collision.gameObject.CompareTag("Enemy1") && !collision.gameObject.CompareTag("Enemy2") && !collision.gameObject.CompareTag("Enemy3"))
        {
            Destroy(gameObject);
        }
    }

 
}