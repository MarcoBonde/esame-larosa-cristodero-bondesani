using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDestroyer : MonoBehaviour
{
    public PolygonCollider2D collide;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyThis() {
        StartCoroutine(DestroyMe());
    }
    IEnumerator DestroyMe() {
        collide.enabled=false;
        sprite.enabled=false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
