using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{
    // Start is called before the first frame update

    static float range = 0;
    static float cooldownRate = 0;
    static float damageMultiplyer = 0;
    static float speed = 0;
    static float maxHealth = 0;
    static float currentHealth = maxHealth;
    static float coins = 0;
    static float currentTime = 0f;
    public static bool isTimeRunning = false;
    const float upgradeCost = 50;
    static int escapeAttempts = 0;
    static UIManager uiManager;
    public static bool hasRocketPart = false;


    private void Awake()
    {
        range = PlayerPrefs.GetFloat("range", 3f);
        cooldownRate = PlayerPrefs.GetFloat("cooldownRate", 1f);
        damageMultiplyer = PlayerPrefs.GetFloat("damageMultiplyer", 10f);
        speed = PlayerPrefs.GetFloat("speed", 5f);
        maxHealth = PlayerPrefs.GetFloat("maxHealth", 20f);
        currentHealth = maxHealth;
        coins = PlayerPrefs.GetFloat("coins", 0f);
        escapeAttempts = PlayerPrefs.GetInt("ecapeAttempts", 0);
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    public static float GetCurrentTime()
    {
        return currentTime;
    }

    public static void StartTimer()
    {
        currentTime = Time.realtimeSinceStartup;
        isTimeRunning = true;
        Time.timeScale = 1;
    }

    public static void StopTimer()
    {
        isTimeRunning = false;
        Time.timeScale = 0;
    }

    public static int getAttempts() => escapeAttempts;
  

    public static void addRange(float rangeIncrease)
    {
        if(coins - upgradeCost >=0)
        {
            coins -= upgradeCost;
            uiManager.setCoinsLabel(coins);
            range += range * rangeIncrease;
            saveStats();
        }


    }

    public static void addCoins(float coinsIncrease)
    {
        coins += coinsIncrease;
        uiManager.setCoinsLabel(coins);
        saveStats();
    }




    public static void addCooldownRate(float cooldownRateIncrease)
    {
        if (coins - upgradeCost >= 0)
        {
            coins -= upgradeCost;
            uiManager.setCoinsLabel(coins);
            cooldownRate += cooldownRate * cooldownRateIncrease;
            saveStats();
        }
    }

    public static void addDamage(float damageIncrease)
    {

        if (coins - upgradeCost >= 0)
        {
            coins -= upgradeCost;
            uiManager.setCoinsLabel(coins);
            damageMultiplyer += damageMultiplyer * damageIncrease;
            saveStats();
        }
    }

    public static void addSpeed(float speedIncrease)
    {
        if (coins - upgradeCost >= 0)
        {
            coins -= upgradeCost;
            uiManager.setCoinsLabel(coins);
            speed += speedIncrease;
            saveStats();
        }
    }

    public static void addMaxHealth(float maxHealthIncrease)
    {
        if (coins - upgradeCost >= 0)
        {
            coins -= upgradeCost;
            uiManager.setCoinsLabel(coins);
            maxHealth += maxHealth * maxHealthIncrease;
            saveStats();
        }

    }

    public static float getRange() => range;

    public static float getCooldownRate() => cooldownRate;

    public static float getDamageMultiplyer() => damageMultiplyer;

    public static float getSpeed() => speed;

    public static float getMaxHealth() => maxHealth;

    public static float getCurrentHealth() => currentHealth;

    public static float getCoins() => coins;

    public static void damagePlayer(float damage)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            AudioSource playerAudioSource = player.GetComponent<AudioSource> ();
            playerAudioSource.Play ();
        }

        currentHealth -= damage;
        if(currentHealth < 0)
        {
            //death here;

            PlayerPrefs.SetInt("ecapeAttempts", PlayerPrefs.GetInt("ecapeAttempts", 0) + 1);
            //SceneManagerMenu.StartGame();
            SceneManager.LoadScene(3);

        }
        UIManager.updateHealthBarUI();

    }

    public static void saveStats()
    {
        PlayerPrefs.SetFloat("maxHealth", maxHealth);
        PlayerPrefs.SetFloat("range", range);
        PlayerPrefs.SetFloat("cooldownRate", cooldownRate);
        PlayerPrefs.SetFloat("speed", speed);
        PlayerPrefs.SetFloat("damageMultiplyer", damageMultiplyer);
        PlayerPrefs.SetFloat("coins", coins);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            damagePlayer(100);
        }
    }
}
