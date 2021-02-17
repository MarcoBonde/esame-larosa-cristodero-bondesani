using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2life : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ammocrate;

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SniperBullet") || collision.gameObject.CompareTag("RocketBullet"))
        {
            Instantiate(ammocrate, this.transform.position, new Quaternion());
            Destroy(gameObject);
            
        }
    }
}
