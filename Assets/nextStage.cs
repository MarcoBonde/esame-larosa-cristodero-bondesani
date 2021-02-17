using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class nextStage : MonoBehaviour
{
    public static nextStage Singleton;
    public UnityEvent NextStage;
    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NextStage.Invoke();
        }
    }
}
