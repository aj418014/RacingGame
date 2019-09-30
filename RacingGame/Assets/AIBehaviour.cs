using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
    public List<Transform> checkpoints;
    public Transform currentCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        currentCheckpoint = checkpoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(currentCheckpoint);
        GetComponent<Rigidbody>().AddForce(transform.forward * 1200 * Time.deltaTime);
    }
    public void  IncrementCheckpoint()
    {
        for(int i = 0; i < checkpoints.Count; i++)
        {
            if (i == checkpoints.Count - 1)
            {
                currentCheckpoint = checkpoints[0];
                return;
            }
            if(currentCheckpoint == checkpoints[i])
            {
                currentCheckpoint = checkpoints[i + 1];
                return;
            }

        }
    }
}
