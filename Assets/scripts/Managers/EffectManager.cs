using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject Player;

    public enum Effects
    {
        Orbs = 0,
        Lightning =1,
        Repel = 2,
        Tornado = 3,
        FireBall = 4,
        BasicAttack = 5,
    }

    public static Dictionary<Effects,IEffect> EffectList = new Dictionary<Effects,IEffect>();
    static Dictionary<Effects, float> EffectCooldowns = new Dictionary<Effects, float>();
    static Dictionary<Effects, float> currentEffectCooldowns = new Dictionary<Effects, float>();
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public static void AddEffect(Effects type,int level, float cooldown, IEffect effect)
    {
        Debug.Log("Trying to add the " + type.ToString() + " Effect");
        if(EffectList.ContainsKey(type))
        {
            EffectList[type] = effect; 
            EffectCooldowns[type] = cooldown;
            currentEffectCooldowns[type] = 0f;
        }
        else
        {
            EffectList.Add(type, effect);
            EffectCooldowns.Add(type, cooldown);
            currentEffectCooldowns.Add(type, 0);
        }

        if(EffectList.ContainsKey(type) == true)
        {
            Debug.Log("Yuup we have added it");
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
                    currentEffectCooldowns[Effect] += (Time.deltaTime*StatManager.getCooldownRate());
                }
                else
                {
                    //spawn effect
                   // Debug.Log("Spawning " + Effect.ToString());
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
