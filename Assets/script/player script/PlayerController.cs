using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour
{
    // Stores a reference of the Rigidbody2D component (if any)
    Rigidbody2D _rigidbody;
    public float jumpMultiplier = 10;
    bool _isJumping;
    public Transform gun;
    public Transform bullet_gun;
    public Transform bullet_sniper;
    public Transform bullet_rocket;
    private Transform shooting_bullet;
    private int ammo_sniper;
    private int ammo_rocket;
    public Text sniperammo;
    public Text rocketammo;
    private int ammosniper;
    private int ammorocket;


    private bool shouldJump, shouldStomp, shouldChangeLeft, shouldChangeRight, shouldShoot;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        InputManager.Singleton.SwipeUp.AddListener(Jump);
        InputManager.Singleton.Shoot.AddListener(Shoot);
        InputManager.Singleton.SwipeLeft.AddListener(ChangeWeaponLeft);
        InputManager.Singleton.SwipeRight.AddListener(ChangeWapeonRight);
        InputManager.Singleton.SwipeDown.AddListener(StompGround);
        shooting_bullet = bullet_gun;
        ammo_rocket = 2;
        ammo_sniper = 2;
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
    }

    private void BulletToShoot(bool swipeRight) {
        if (shooting_bullet == bullet_gun)
        {
            if (swipeRight && ammo_sniper != 0)
            {
                shooting_bullet = bullet_sniper;
            }
            else if (swipeRight && ammo_rocket != 0)
            {
                shooting_bullet = bullet_rocket;
            }
            else if (!swipeRight && ammo_rocket != 0)
            {
                shooting_bullet = bullet_rocket;
            }
            else if(!swipeRight && ammo_sniper!=0)
            {
                shooting_bullet = bullet_sniper;
            }
        }
        else if (shooting_bullet == bullet_rocket)
        {
            if (swipeRight)
            {
                shooting_bullet = bullet_gun;
            }
            else if (!swipeRight && ammo_sniper != 0)
            {
                shooting_bullet = bullet_sniper;
            }
            else
            {
                shooting_bullet = bullet_gun;
            }
        }
        else
        {
            if (swipeRight && ammo_rocket != 0)
            {
                shooting_bullet = bullet_rocket;
            }
            else
            {
                shooting_bullet = bullet_gun;
            }
        }
        Debug.Log(" Sparerò: " +shooting_bullet);
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
            Instantiate(shooting_bullet, gun, false);
            if (shooting_bullet == bullet_sniper) {
                ammo_sniper = ammo_sniper - 1;
                if (ammo_sniper == 0)
                {
                    BulletToShoot(true);
                }
            } else if (shooting_bullet== bullet_rocket) {
                ammo_rocket = ammo_rocket - 1;
                if (ammo_rocket == 0)
                {
                    BulletToShoot(true);
                }
            }
            shouldShoot = false;
        }
        if (shouldChangeLeft)
        {
            //TODO aggiungere il cambio arma a sinistra
            BulletToShoot(false);
            shouldChangeLeft = false;
        }
        if (shouldChangeRight)
        {
            //TODO aggiungere il cambio arma a destra
            BulletToShoot(true);
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

        if (collision.gameObject.CompareTag("Rocketammo"))

        {
            ammo_rocket = +1;
            ammorocket += 1;
            rocketammo.text = ammorocket.ToString();
            
        }

        if (collision.gameObject.CompareTag("Sniperammo"))

        {
            ammo_sniper = +1;
            ammosniper += 1;
            sniperammo.text = ammosniper.ToString();
            
        }
    }

 
}