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
    GameObject pausePanel;
    GameObject startPanel;

    private float startTime;
    private float introTime = 0;

    private void Awake()
    {
        coinsLabel = GameObject.FindGameObjectWithTag("coinLabel").GetComponent<TextMeshProUGUI>();
        timeLabel = GameObject.FindGameObjectWithTag("timeLabel").GetComponent<TextMeshProUGUI>();
        shopPanel = GameObject.FindGameObjectWithTag("shopPanel");
        startPanel = GameObject.FindGameObjectWithTag("startPanel");
        pausePanel = GameObject.FindGameObjectWithTag("pausePanel");
        healthBar = GameObject.FindGameObjectWithTag("healthBar").GetComponent <Slider>();
        
    }

    void Start()
    {
        pausePanel.SetActive(false);
        StatManager.StartTimer();
        startTime = Time.realtimeSinceStartup;
        coinsLabel.text = "Coins: " + StatManager.getCoins();
        gameInit();
        healthBarInit();
    }

    public static void toggleShopPanel()
    {
        shopPanel.SetActive(shopPanel.activeInHierarchy ?  false : true);
    }

    void gameInit()
    {
        startPanel.GetComponentsInChildren<TextMeshProUGUI>()[0].text = StatManager.getAttempts().ToString();
    }

    void introEffect()
    {
        if (startPanel.activeInHierarchy) {

            introTime += Time.deltaTime/2;
            startPanel.GetComponent<Image>().color = Color.Lerp(Color.black, Color.clear,introTime);
            if (introTime >= 1)
            {
                introTime = 1;
                startPanel.SetActive(false);
            }


        }
    }

    public void togglePausePanel(bool overrideKey) 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            try
            {
                Debug.Log("What we have: " + pausePanel.activeInHierarchy);
                if (pausePanel.activeInHierarchy == false)
                {
                    Debug.Log("1");
                    pausePanel.SetActive(true);
                    StatManager.StopTimer();
                    return;

                }
                else if(pausePanel.activeInHierarchy == true)
                {
                    Debug.Log('2');
                    pausePanel.SetActive(false);
                    StatManager.StartTimer();
                    return;
                }
            }
            catch
            {

            }
            
        }
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
        togglePausePanel(false);
        introEffect();
        // if game in certain state 
        // StatManager.StopTimer();
        // once back 
        //StatManager.StartTimer();
        //startTime = Time.realtimeSinceStartup - currentTime;
    }
}
