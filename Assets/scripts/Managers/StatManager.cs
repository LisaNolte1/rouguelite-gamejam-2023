using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    // Start is called before the first frame update

    static float range = PlayerPrefs.GetFloat("range", 3f);
    static float cooldownRate = PlayerPrefs.GetFloat("cooldownRate", 1f);
    static float damageMultiplyer = PlayerPrefs.GetFloat("damageMultiplyer", 1f);
    static float speed = PlayerPrefs.GetFloat("speed",10f);
    static float maxHealth = PlayerPrefs.GetFloat("maxHealth", 10f);
    static float currentHealth = maxHealth;
    static float coins = PlayerPrefs.GetFloat("coins", 0f);
    static float currentTime = 0f;
    public static bool isTimeRunning = false;



    void Start()
    {
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
        range += range * rangeIncrease;
        saveStats();

    }

    public static void addCoins(float coinsIncrease)
    {
        coins += coinsIncrease;
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().setCoinsLabel(coins);
        saveStats();
    }

    public static float getRange() => range;

    public static float getCooldownRate() => cooldownRate;

    public static float getDamageMultiplyer() => damageMultiplyer;

    public static float getSpeed() => speed;

    public static float getMaxHealth() => maxHealth;

    public static float getCurrentHealth() => currentHealth;

    public static float getCoins() => coins;

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
