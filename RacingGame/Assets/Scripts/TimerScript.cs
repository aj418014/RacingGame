using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)

            return;

        float t = Time.time - startTime;

        float minutes = ((int)t / 60);
        float seconds = ((int)t % 60);
        int centiseconds = (int)((t - (minutes * 60) - seconds) * 100);
        timerText.text = minutes + ":" + seconds + ':' + centiseconds;
    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.yellow;
    }
}
