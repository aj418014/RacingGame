using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laps : MonoBehaviour
{
    public int currentLap;
    public bool passedCheckPoint = false;
    public bool hasFinished = false;
    public Transform[] checkpoints;
    public Transform currentCheckpoint;
    void ChangeCheckpoint()
    {
        for(int i = 0; i < checkpoints.Length)
    }
}
