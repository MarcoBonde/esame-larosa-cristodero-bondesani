using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2life : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ammocrate;
    public PolygonCollider2D collide;
    public SpriteRenderer sprite;
    public raycast script;
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SniperBullet") || collision.gameObject.CompareTag("RocketBullet"))
        {
            Instantiate(ammocrate, this.transform.position, new Quaternion());
            StartCoroutine(DestroyMe());

        }
    }
    IEnumerator DestroyMe()
    {
        collide.enabled = false;
        sprite.enabled = false;
        script.enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
