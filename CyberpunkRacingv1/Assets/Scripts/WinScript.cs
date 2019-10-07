using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinScript : MonoBehaviour
{
    public List<GameObject> carboi;
    public int maxLaps;
    public List<GameObject> places;
    bool isACarboi;
    public Transform[] placesDisplay;
    public GameObject[] placesBackground;
    int k = 0;
    float timer = 10;
    bool playTimer = false;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (playTimer == true)
            timer -= Time.deltaTime;
        if (timer < 0)
            SceneManager.LoadScene(0);
    }
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
                placesDisplay[k].GetComponent<Text>().text = (k + 1).ToString() + ": " + other.gameObject.name;
                placesBackground[k].SetActive(true);
                other.gameObject.GetComponent<Laps>().hasFinished = true;
                places.Add(other.gameObject);
                if(other.gameObject.tag == "Player")
                    GameObject.Find("TimeText").GetComponent<TimerScript>().Finish();
                k++;

            }
            else
            {
                other.gameObject.GetComponent<Laps>().currentLap++;
                other.gameObject.GetComponent<Laps>().passedCheckPoint = false;
            }
            if(carboi.Count == places.Count)
            {
                playTimer = true;
            }


        }

    }
}
