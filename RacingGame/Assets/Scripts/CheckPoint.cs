using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public List<GameObject> carboi;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < carboi.Count; i++)
        {
            if (other.gameObject == carboi[i])
            {
                other.gameObject.GetComponent<Laps>().passedCheckPoint = true;
                return;
            }
        }
    }

}
