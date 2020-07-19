using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{ public Transform prefab;
    public Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("fire"))
        {
            Instantiate(prefab);
            rb.velocity = new Vector3(10, 0, 0);
        }
    }
}
