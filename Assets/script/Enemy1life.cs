using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1life : MonoBehaviour
{
    // Start is called before the first frame update
   

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        {

            if (collision.gameObject.CompareTag("GunBullet") && !collision.gameObject.CompareTag("SniperBullet") && !collision.gameObject.CompareTag("RocketBullet"))
            {
                Destroy(gameObject);
            }
        }
    }
}
