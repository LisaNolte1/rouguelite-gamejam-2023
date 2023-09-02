using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static TextMeshProUGUI coinsLabel;
    static TextMeshProUGUI timeLabel;
    static TextMeshProUGUI killsLabel;
    static Slider healthBar;
    public static GameObject shopPanel;
    GameObject pausePanel;
    GameObject startPanel;
    static GameObject notificationPanel;
    private static UIManager instance;
    private float startTime;
    private float introTime = 0;
    private const float itemTimer = 2f;
    private static float itemCounter = 0f;
    private static bool notifcationActive = false;

    private void Awake()
    {
        coinsLabel = GameObject.FindGameObjectWithTag("coinLabel").GetComponent<TextMeshProUGUI>();
        shopPanel = GameObject.FindGameObjectWithTag("shopPanel");
        startPanel = GameObject.FindGameObjectWithTag("startPanel");
        pausePanel = GameObject.FindGameObjectWithTag("pausePanel");
        notificationPanel = GameObject.FindGameObjectWithTag("notificationPanel");
        healthBar = GameObject.FindGameObjectWithTag("healthBar").GetComponent<Slider>();
        killsLabel = GameObject.FindGameObjectWithTag("killsLabel").GetComponent<TextMeshProUGUI>();

        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }else if(instance == null)
        {
            instance = this;
        }
        
    }

    void Start()
    {
        pausePanel.SetActive(false);
        notificationPanel.SetActive(false);
        StatManager.StartTimer();
        startTime = Time.realtimeSinceStartup;
        gameInit();
        healthBarInit();
        coinsLabel.text = StatManager.getCoins().ToString();
    }

    public static void toggleShopPanel()
    {
        shopPanel.SetActive(shopPanel.activeInHierarchy ?  false : true);
    }

    public static void setKills(int kills)
    {
        killsLabel.text = kills.ToString() +"/" + GameManager.maxKills.ToString();
    }

    void gameInit()
    {
        if (startPanel)
        {
            startPanel.GetComponentsInChildren<TextMeshProUGUI>()[0].text = StatManager.getAttempts().ToString();
        }
        
    }

    void introEffect()
    {
        if (startPanel && startPanel.activeInHierarchy) {

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
        if (Input.GetKeyDown(KeyCode.Escape) || overrideKey)
        {
            Debug.Log("Trigger");

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

    public static void toggleNotification(string name, string description)
    {
        notificationPanel.SetActive(true);
        notifcationActive = true;
        itemCounter = 0f;
        notificationPanel.GetComponentsInChildren<TextMeshProUGUI>()[0].text = name;
        notificationPanel.GetComponentsInChildren<TextMeshProUGUI>()[1].text = description;
        itemCounter = itemTimer;

    }

    void notifcationOff()
    {
        if(notifcationActive == true)
        {
            itemCounter -= Time.deltaTime;
            if (itemCounter <= 0)
            {
                notificationPanel.SetActive(false);
                notifcationActive=false;
            }
        }
   
    }

    public void setCoinsLabel(float coins)
    {
        coinsLabel.text =  coins.ToString();
    }

    static void healthBarInit()
    {
        Debug.Log("Changing values");
        healthBar.maxValue = StatManager.getMaxHealth();
        healthBar.value = StatManager.getCurrentHealth();
    }

    public static void updateHealthBarUI()
    {
        healthBarInit();
    }

    void Update()
    {

        togglePausePanel(false);
        introEffect();
        notifcationOff();
        // if game in certain state 
        // StatManager.StopTimer();
        // once back 
        //StatManager.StartTimer();
        //startTime = Time.realtimeSinceStartup - currentTime;
    }
}
