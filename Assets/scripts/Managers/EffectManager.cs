using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        Bolder = 5,
        LightningTornado = 6,
        PyroBlast = 7,
        BasicAttack = 8, //must be last!!!!!!
    }

    public static Dictionary<Effects,IEffect> EffectList = new Dictionary<Effects,IEffect>();
    static Dictionary<Effects, float> EffectCooldowns = new Dictionary<Effects, float>();
    static Dictionary<Effects, float> currentEffectCooldowns = new Dictionary<Effects, float>();

    private void Awake()
    {
        EffectList.Clear();
        EffectCooldowns.Clear();
        currentEffectCooldowns.Clear();
    }

    private void OnDestroy()
    {
        EffectList.Clear();
        EffectCooldowns.Clear();
        currentEffectCooldowns.Clear();
    }
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

        checkForUpgrades();
        
    }

    static void checkForUpgrades()
    {
        Debug.Log("We in the check");
        Debug.Log(EffectList.ContainsKey(Effects.Lightning));
        Debug.Log(EffectList.ContainsKey(Effects.Tornado));
        Debug.Log(!EffectList.ContainsKey(Effects.LightningTornado));
        //LightningTornado
        if(EffectList.ContainsKey(Effects.Lightning) && EffectList.ContainsKey(Effects.Tornado) && !EffectList.ContainsKey(Effects.LightningTornado))
        {
            EffectList.Remove(Effects.Lightning);
            EffectCooldowns.Remove(Effects.Lightning);
            currentEffectCooldowns.Remove(Effects.Lightning);
            EffectList.Remove(Effects.Tornado);
            EffectCooldowns.Remove(Effects.Tornado);
            currentEffectCooldowns.Remove(Effects.Tornado);
            EffectList.Add(Effects.LightningTornado, new LightningTornado());
            EffectCooldowns.Add(Effects.LightningTornado, LightningTornado.cooldown);
            currentEffectCooldowns.Add(Effects.LightningTornado, 0);
            Debug.Log("Added lightning Tornado");
        }
        
        if(EffectList.ContainsKey(Effects.Bolder) && EffectList.ContainsKey(Effects.FireBall) && !EffectList.ContainsKey(Effects.PyroBlast))
        {
            EffectList.Remove(Effects.Bolder);
            EffectCooldowns.Remove(Effects.Bolder);
            currentEffectCooldowns.Remove(Effects.Bolder);
            EffectList.Remove(Effects.FireBall);
            EffectCooldowns.Remove(Effects.FireBall);
            currentEffectCooldowns.Remove(Effects.FireBall);
            EffectList.Add(Effects.PyroBlast, new PyroBlast());
            EffectCooldowns.Add(Effects.PyroBlast, PyroBlast.cooldown);
            currentEffectCooldowns.Add(Effects.PyroBlast, 0);
            Debug.Log("Added Pyroblast");
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
