using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private GameObject curStage;
    private GameObject lastStage;
    public GameObject[] stages;
    private bool next=false;
    private Quaternion q = new Quaternion();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextStage());
        PlayerController.Singleton.NextStage.AddListener(ShouldNextStage);
        curStage = GameObject.FindGameObjectWithTag("stage");
    }
    void ShouldNextStage() {
        next = true;
    }
    IEnumerator NextStage()
    {
        while (true)
        {
            if (next)
            {
                GameObject stageTemp = lastStage;
                lastStage = curStage;
                Destroy(stageTemp);
                int num = Random.Range(1, stages.Length);
                curStage = stages[num];
                GameObject spawner = GameObject.FindWithTag("endstage");
                Instantiate(curStage, spawner.transform.position, q);
                Destroy(spawner);
                yield return new WaitForSeconds(1);
                next = false;
            }
            yield return new WaitForFixedUpdate();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
