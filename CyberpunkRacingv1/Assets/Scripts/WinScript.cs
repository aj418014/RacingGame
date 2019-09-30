using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public List<GameObject> carboi;
    public int maxLaps;
    public List<GameObject> places;
    bool isACarboi;

    private void OnTriggerEnter(Collider other)
    {
        isACarboi = false;
        if (other.gameObject.GetComponent<Laps>().passedCheckPoint ==true)
        {
            for(int i = 0; i < carboi.Count; i++)
            {
                if (other.gameObject == carboi[i])
                    isACarboi = true;
            }
            if (isACarboi == true && other.gameObject.GetComponent<Laps>().currentLap == maxLaps && other.gameObject.GetComponent<Laps>().hasFinished == false)
            {
                other.gameObject.GetComponent<Laps>().hasFinished = true;
                places.Add(other.gameObject);

            }
            else
            {
                other.gameObject.GetComponent<Laps>().currentLap++;
                other.gameObject.GetComponent<Laps>().passedCheckPoint = false;
            }
            if(places.Count == carboi.Count)
            {
                GameObject.Find("TimeText").GetComponent<TimerScript>().Finish();

                for (int i = 0; i < places.Count; i++)
                {
                    string placement = (i + 1).ToString();
                    print(placement + ':' + places[i].name);
                }
            }
        }

    }
}
