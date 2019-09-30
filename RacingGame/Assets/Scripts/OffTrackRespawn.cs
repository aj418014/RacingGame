using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffTrackRespawn : MonoBehaviour
{
    public List<Transform> checkpoints;
    public Transform deadTransform;
    public Transform closestCheckpoint;
    float closestDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ImDead()
    {
        deadTransform = transform;
        for (int i = 0; i < checkpoints.Count; i++)
        {
            if (closestDistance > Vector3.Distance(deadTransform.position, checkpoints[i].position))
            {
                closestDistance = Vector3.Distance(deadTransform.position, checkpoints[i].position);
                closestCheckpoint = checkpoints[i];
            }
        }
        transform.position = closestCheckpoint.position;
    } 
}

