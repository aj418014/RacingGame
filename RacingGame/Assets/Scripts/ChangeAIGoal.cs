using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAIGoal : MonoBehaviour
{
    public Transform[] myCheckpoints;
    private void Awake()
    {
        myCheckpoints = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            myCheckpoints[i] = transform.GetChild(i);
        }
        
    }
    public void ChangeGoal(GameObject enemy)
    {
        enemy.GetComponent<AIBehaviour>().IncrementCheckpoint();
        print("Enemy Checkpoint Reached");
    }
    public Transform SetGoal(int minPriority, int maxPriority)
    {
        int randomNumber = Random.Range(1, 6);
       if(myCheckpoints[randomNumber].GetComponent<AICheckpointTrigger>().priority <= maxPriority && myCheckpoints[randomNumber].GetComponent<AICheckpointTrigger>().priority >= minPriority)
        {
            return myCheckpoints[randomNumber];
        }
       else
        {
            return SetGoal(minPriority, maxPriority);
        }
    }
}
