using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;

    public enum Effects
    {
        Orbs = 0,
        Lightning =1,
        Repel = 2,
    }

    static Dictionary<Effects,IEffect> EffectList = new Dictionary<Effects,IEffect>();
    static Dictionary<Effects, float> EffectCooldowns = new Dictionary<Effects, float>();
    static Dictionary<Effects, float> currentEffectCooldowns = new Dictionary<Effects, float>();
    static Dictionary<Effects,int> EffectLevels = new Dictionary<Effects,int>();
    void Start()
    {
        
    }

    public static void AddEffect(Effects type,int level, float cooldown, IEffect effect)
    {
        if(EffectList.ContainsKey(type))
        {
            EffectList[type] = effect; 
            EffectCooldowns[type] = cooldown;
            EffectLevels[type] = level;
            currentEffectCooldowns[type] = 0f;
        }
        else
        {
            EffectList.Add(type, effect);
            EffectCooldowns.Add(type, cooldown);
            EffectLevels.Add(type, level);
            currentEffectCooldowns.Add(type, 0);
        }
        
    }


    void EffectCooldownCount()
    {
        foreach (Effects Effect in Enum.GetValues(typeof(Effects)))
        {
            if( EffectCooldowns.ContainsKey(Effect))
            {
                if (currentEffectCooldowns[Effect] < EffectCooldowns[Effect])
                {
                    currentEffectCooldowns[Effect] += Time.deltaTime;
                }
                else
                {
                    //spawn effect
                    EffectList[Effect].ApplyEffect(Player);
                    currentEffectCooldowns[Effect] = 0f;
                }
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        EffectCooldownCount();
    }
}
