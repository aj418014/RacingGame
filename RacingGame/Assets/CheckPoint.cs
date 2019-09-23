using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject carboi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == carboi)
        {
            other.gameObject.GetComponent<Laps>().passedCheckPoint = true;
        }
    }

}
