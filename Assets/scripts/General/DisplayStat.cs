using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisplayStat : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI label;

    public enum statType
    {
        speed = 1,
        cooldown = 2,
        range = 3,
        damage = 4,
        maxHealth = 5,

    }

    public statType updateType;

    void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
    }

    void updateTypeCheck()
    {
        switch(updateType)
        {
            case statType.speed:
                label.text = StatManager.getSpeed().ToString("F2");
                break;
                case statType.cooldown:
                label.text = StatManager.getCooldownRate().ToString("F2");
                break;
                case statType.range:
                label.text = StatManager.getRange().ToString("F2");
                break;
                case statType.damage:
                label.text = StatManager.getDamageMultiplyer().ToString("F2");
                break;
                case statType.maxHealth:
                label.text = StatManager.getMaxHealth().ToString("F2");
                break;
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateTypeCheck();
    }
}
