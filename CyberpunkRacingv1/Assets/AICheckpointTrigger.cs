using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICheckpointTrigger : MonoBehaviour
{
    public int priority;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && other.GetComponent<AIBehaviour>().currentCheckpoint == this.transform)
        {
            gameObject.GetComponentInParent<ChangeAIGoal>().ChangeGoal(other.gameObject);
        }
    }
}
