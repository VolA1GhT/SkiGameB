using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private DateTime raceStart;
    private TimeSpan raceTime;
    private bool racing = false;
    private TimeSpan penaltyTime;

    public delegate void TimerEvent();
    [SerializeField] private int penaltyValue = 3;

    private void OnEnable()
    {
        StartGate.StartRace += OnRaceStart;
        FinishGate.FinishRace += OnRaceFinish;
        SlalomFlag.RacePenalty += AddRacePenalty;

    }

    void AddRacePenalty()
    {
        penaltyTime += new TimeSpan(0, 0, penaltyValue);
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
            raceTime = DateTime.Now - raceStart + penaltyTime;
        Debug.Log("Race Time " + raceTime);
    }
}
