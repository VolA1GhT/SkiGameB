using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private DateTime raceStart;
    private TimeSpan raceTime;
    private bool racing = false;


    public delegate void TimerEvent();

    private void OnEnable()
    {
        StartGate.StartRace += OnRaceStart;
        FinishGate.FinishRace += OnRaceFinish;
    }

    void OnRaceStart()
    {
        racing = true;
        raceStart = DateTime.Now;
        Debug.Log("Race Starter");
    }

    void OnRaceFinish()
    {
        racing = false;
        Debug.Log("Race Finished");
    }
    private void Update()
    {
        if (racing)
            raceTime = DateTime.Now - raceStart;
        Debug.Log("Race Time " + raceTime);
    }
}
