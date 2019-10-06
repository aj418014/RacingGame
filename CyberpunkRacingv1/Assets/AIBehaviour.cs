using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    GameObject checkpointParent;
    public Transform[] checkpoints;
    public Transform currentCheckpoint;
    public int level;
    int minPriority;
    int maxPriority;
    Quaternion previousRotation;
    float force = 800;
    // Start is called before the first frame update
    void Start()
    {
        checkpointParent = GameObject.Find("AI Checkpoints");
        checkpoints = new Transform[checkpointParent.transform.childCount];
        for(int i = 0; i < checkpointParent.transform.childCount; i++)
        {
            checkpoints[i] = checkpointParent.transform.GetChild(i);
        }
        switch (level)
        {
            case (1):
                minPriority = 3;
                maxPriority = 6;
                break;
            case (2):
                minPriority = 3;
                maxPriority = 6;
                break;
            case (3):
                minPriority = 2;
                maxPriority = 5;
                break;
            case (4):
                minPriority = 1;
                maxPriority = 4;
                break;
            case (5):
                minPriority = 1;
                maxPriority = 2;
                break;              
        }
        currentCheckpoint = checkpoints[0].GetComponent<ChangeAIGoal>().SetGoal(minPriority, maxPriority);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(currentCheckpoint.position - transform.position), .08f);
        GetComponent<Rigidbody>().AddForce(transform.forward * force * Time.deltaTime);
        //if (previousRotation != transform.rotation)
        //    force = 200;
        //else
        //    force = 800;
        //previousRotation = transform.rotation;
    }
    public void  IncrementCheckpoint()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            if (i == checkpoints.Length - 1)
            {
                currentCheckpoint = checkpoints[0].GetComponent<ChangeAIGoal>().SetGoal(minPriority, maxPriority);
                return;
            }
            if(currentCheckpoint.parent == checkpoints[i])
            {
                currentCheckpoint = checkpoints[i + 1].GetComponent<ChangeAIGoal>().SetGoal(minPriority, maxPriority);
                return;
            }

        }
    }
}
