using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedometer : MonoBehaviour
{
    // Start is called before the first frame update
    public  float speed;
    public float speedBullet;
    void Start()
    {
        speed = 5.0f;   
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed + (0.01f*Time.deltaTime);
        Debug.Log(speed + "");
        speedBullet = speed + 3.0f ;
    }
}
