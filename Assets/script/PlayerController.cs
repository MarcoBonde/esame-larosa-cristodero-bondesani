using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    // Stores a reference of the Rigidbody2D component (if any)
    Rigidbody2D _rigidbody;
    public float jumpMultiplier = 10;
    bool _isJumping;
    public Transform bullet_gun;
    public Transform gun;
    public Transform bullet_sniper;
    public Transform bullet_rocket;


    private bool shouldJump, shouldStomp, shouldChangeLeft, shouldChangeRight, shouldShoot;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        InputManager.Singleton.SwipeUp.AddListener(Jump);
        InputManager.Singleton.Shoot.AddListener(Shoot);
        InputManager.Singleton.SwipeLeft.AddListener(ChangeWeaponLeft);
        InputManager.Singleton.SwipeRight.AddListener(ChangeWapeonRight);
        InputManager.Singleton.SwipeDown.AddListener(StompGround);
    }

    void Jump()
    {
        //se non sta saltando, allora dovrebbe saltare.
        if (!_isJumping)
        {
            shouldJump = true;
        }
    }
    void Shoot()
    {
        shouldShoot = true;
    }
    void ChangeWeaponLeft()
    {
        shouldChangeLeft = true;
    }
    void ChangeWapeonRight()
    {
        shouldChangeRight = true;
    }
    void StompGround()
    {
        shouldStomp = true;
    }
    private void Update()
    {
        /*
        if (Input.GetButtonDown("Jump") && !_isJumping)
        {
            _isJumping = true;

            Vector2 jumpForce = Vector2.up * jumpMultiplier;

            _rigidbody.AddForce(jumpForce, ForceMode2D.Impulse);
        }
        
        */
    }

    private void FixedUpdate()
    {
        if (shouldJump)
        {
            _isJumping = true;
            Vector2 jumpForce = Vector2.up * jumpMultiplier;
            _rigidbody.AddForce(jumpForce, ForceMode2D.Impulse);
            shouldJump = false;
        }
        if (shouldStomp)
        {
            Vector2 jumpForce = Vector2.down * jumpMultiplier;
            _rigidbody.AddForce(jumpForce, ForceMode2D.Impulse);
            shouldStomp = false;
        }
        if (shouldShoot)
        {
            Instantiate(bullet_gun, gun, false);
            shouldShoot = false;
        }
        if (shouldChangeLeft)
        {
            //TODO aggiungere il cambio arma a sinistra
            shouldChangeLeft = false;
        }
        if (shouldChangeRight)
        {
            //TODO aggiungere il cambio arma a destra
            shouldChangeRight = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _isJumping = false;
        }

        if (collision.gameObject.CompareTag("Enemy1") || collision.gameObject.CompareTag("Enemy2") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy3"))
        {
            Destroy(gameObject);
        }
    }

 
}