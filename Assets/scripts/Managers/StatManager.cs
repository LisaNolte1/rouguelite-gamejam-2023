using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private void Awake()
    {
        range = PlayerPrefs.GetFloat("range", 3f);
        cooldownRate = PlayerPrefs.GetFloat("cooldownRate", 1f);
        damageMultiplyer = PlayerPrefs.GetFloat("damageMultiplyer", 1f);
        speed = PlayerPrefs.GetFloat("speed", 10f);
        maxHealth = PlayerPrefs.GetFloat("maxHealth", 10f);
        currentHealth = maxHealth;
        coins = PlayerPrefs.GetFloat("coins", 0f);
    }

    public static float GetCurrentTime()
    {
        return currentTime;
    }

    public static void StartTimer()
    {
        currentTime = Time.realtimeSinceStartup;
        isTimeRunning = true;
    }

    public static void StopTimer()
    {
        isTimeRunning = false;
    }

    public static void addRange(float rangeIncrease)
    {
        if(coins - upgradeCost >=0)
        {
            coins -= upgradeCost;
            range += range * rangeIncrease;
            saveStats();
        }


    }

    public static void addCoins(float coinsIncrease)
    {
        coins += coinsIncrease;
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().setCoinsLabel(coins);
        saveStats();
    }




    public static void addCooldownRate(float cooldownRateIncrease)
    {
        if (coins - upgradeCost >= 0)
        {
            coins -= upgradeCost;
            cooldownRate += cooldownRate * cooldownRateIncrease;
            saveStats();
        }
    }

    public static void addDamage(float damageIncrease)
    {

        if (coins - upgradeCost >= 0)
        {
            coins -= upgradeCost;
            damageMultiplyer += damageMultiplyer * damageIncrease;
            saveStats();
        }
    }

    public static void addSpeed(float speedIncrease)
    {
        if (coins - upgradeCost >= 0)
        {
            coins -= upgradeCost;
            speed += speed * speed;
            saveStats();
        }
    }

    public static void addMaxHealth(float maxHealthIncrease)
    {
        if (coins - upgradeCost >= 0)
        {
            coins -= upgradeCost;
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
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            //death here;

            PlayerPrefs.SetInt("loopAttempts",PlayerPrefs.GetInt("loopAttempts",0) + 1);

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
        
    }
}
