using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static TextMeshProUGUI coinsLabel;
    static TextMeshProUGUI timeLabel;
    static Slider healthBar;
    public static GameObject shopPanel;

    private float startTime;

    private void Awake()
    {
        coinsLabel = GameObject.FindGameObjectWithTag("coinLabel").GetComponent<TextMeshProUGUI>();
        timeLabel = GameObject.FindGameObjectWithTag("timeLabel").GetComponent<TextMeshProUGUI>();
        shopPanel = GameObject.FindGameObjectWithTag("shopPanel");
        healthBar = GameObject.FindGameObjectWithTag("healthBar").GetComponent <Slider>();
        
    }

    void Start()
    {
        
        StatManager.StartTimer();
        startTime = Time.realtimeSinceStartup;

        coinsLabel.text = "Coins: " + StatManager.getCoins();
        Debug.Log("REEEEEEEEEEEEEEEEE");
        healthBarInit();
    }

    public static void toggleShopPanel()
    {
        shopPanel.SetActive(shopPanel.activeInHierarchy ?  false : true);
    }

    public void setCoinsLabel(float coins)
    {
        coinsLabel.text = "Coins: " + coins;
    }

    static void healthBarInit()
    {
        Debug.Log("Changing values");
        healthBar.maxValue = StatManager.getMaxHealth();
        healthBar.value = StatManager.getCurrentHealth();
    }

    void UpdateTimeLabel(float timeInSeconds)
    {
        try
        {
            int minutes = Mathf.FloorToInt(timeInSeconds / 60);
            int seconds = Mathf.FloorToInt(timeInSeconds % 60);
            string timeString = string.Format("Time: {0}:{1:00}", minutes, seconds);
            timeLabel.text = timeString;
        }
        catch {
            Debug.Log("Caught that steven error");
        }

    }

    public static void updateHealthBarUI()
    {
        healthBarInit();
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
