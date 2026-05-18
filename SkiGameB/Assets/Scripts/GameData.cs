using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour
{
    private static GameData instance;
    public List<float> bestTimes = new List<float>();
    public static GameData Instance
    {
        get { return instance; }
    }
    public string leaderboardKey = "LVL1-";
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddTime(float time)
    {
        bestTimes.Add(time);
    }
}
