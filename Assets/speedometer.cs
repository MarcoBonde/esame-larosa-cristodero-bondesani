using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedometer : MonoBehaviour
{
    // Start is called before the first frame update
    public static float speed;
    public static speedometer singleton;
    void Start()
    {
        singleton = this;
        speed = 5.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed * Time.deltaTime;
    }
    public static float getSpeedWorld() {
        return speed;
    }
    public static float getSpeedEnemyBullet() {
        return speed + 2;
    }
}
