using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinsLabel;
    public TextMeshProUGUI timeLabel;

    private float startTime;

    void Start()
    {
        StatManager.StartTimer();
        startTime = Time.realtimeSinceStartup;
        coinsLabel.text = "Coins: " + StatManager.getCoins();
    }

    public void setCoinsLabel(float coins)
    {
        coinsLabel.text = "Coins: " + coins;
    }

    void UpdateTimeLabel(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        string timeString = string.Format("Time: {0}:{1:00}", minutes, seconds);
        timeLabel.text = timeString;
    }

    void runTime()
    {
        if (StatManager.isTimeRunning)
        {
            float currentTime = Time.realtimeSinceStartup - startTime; //need to subtract start time to get accurate value 
            UpdateTimeLabel(currentTime);
        }
    }

    void Update()
    {

        runTime();
        // if game in certain state 
        // StatManager.StopTimer();
        // once back 
        //StatManager.StartTimer();
        //startTime = Time.realtimeSinceStartup - currentTime;
    }
}
