using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMoveLeft : MonoBehaviour
{
    public float speed = 5;
    public GameObject speeder;
    // Start is called before the first frame update
    void Start()
    {
        speeder = GameObject.FindGameObjectWithTag("speedometer");
    }

    // Update is called once per frame
    void Update()
    {
           
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
            speed = speeder.GetComponent<speedometer>().speed;
    }
}
