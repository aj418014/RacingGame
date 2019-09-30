using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public List<GameObject> carboi;
    public bool isMainCheckpoint = false;
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < carboi.Count; i++)
        {
            if (other.gameObject == carboi[i])
            {
                if (isMainCheckpoint == true)
                {
                    other.gameObject.GetComponent<Laps>().passedCheckPoint = true;
                }
                return;
                
            }
        }
    }

}
