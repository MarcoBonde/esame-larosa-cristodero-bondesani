using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private GameObject stage1;
    private GameObject stage2;
    public GameObject[] stages = new GameObject[10];
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Singleton.NextStage.AddListener(NextStage);
    }
    void NextStage()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if ()
        {

        }
    }
}
