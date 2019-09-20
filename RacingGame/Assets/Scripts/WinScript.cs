using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public GameObject carboi;
    public int maxLaps;
    public List<GameObject> places;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Laps>().passedCheckPoint ==true)
        {
            if (other.gameObject == carboi && other.gameObject.GetComponent<Laps>().currentLap == maxLaps)
            {
                print("Carboi");
                GameObject.Find("TimeText").GetComponent<TimerScript>().Finish();

                places.Add(other.gameObject);

            }
            else
            {
                other.gameObject.GetComponent<Laps>().currentLap++;
                other.gameObject.GetComponent<Laps>().passedCheckPoint = false;
            }
        }

    }
}
