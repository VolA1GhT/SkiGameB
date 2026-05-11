using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    private DateTime raceStart;
    private TimeSpan raceTime;
    private bool racing = false;

    private TimeSpan penaltyTime;
    public delegate void TimerEvent();
    [SerializeField] private int penaltyValue = 3;
    [SerializeField] private TMP_Text raceTimeText;
    [SerializeField] private TMP_Text bestTimeText;

    [SerializeField] private string bestTimeKey = "LVL1BestTime" ;
    private TimeSpan bestTime;



    private void OnEnable()
    {
        StartGate.StartRace += OnRaceStart;
        FinishGate.FinishRace += OnRaceFinish;
        SlalomFlag.RacePenalty += AddRacePenalty;

    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(bestTimeKey))
        {
            int bestTimeTicks = PlayerPrefs.GetInt(bestTimeKey);
            bestTime = new TimeSpan(bestTimeTicks);
            bestTimeText.text = "BEST TIME: " + bestTime.ToString("ss\\:ff");
        }
        else
        {
            bestTime = new TimeSpan(int.MaxValue);
            bestTimeText.text = "BEST TIME: --:--";
        }
    }

    void AddRacePenalty()
    {
        penaltyTime += new TimeSpan(0, 0, penaltyValue);
    }

    void OnRaceStart()
    {
        racing = true;
        raceStart = DateTime.Now;
    }

    void OnRaceFinish()
    {
        racing = false;
        if(raceTime < bestTime)
        {
            bestTime = raceTime;
            bestTimeText.text = "BEST TIME: " + bestTime.ToString("ss\\:ff");
            bestTimeText.color = Color.gold;
            PlayerPrefs.SetInt(bestTimeKey, (int)bestTime.Ticks);
            PlayerPrefs.Save();
        }
    }
    private void Update()
    {
        if (racing)
            raceTime = DateTime.Now - raceStart + penaltyTime;
        raceTimeText.text = " TIME: " + raceTime.ToString("ss\\:ff");
    }
}
