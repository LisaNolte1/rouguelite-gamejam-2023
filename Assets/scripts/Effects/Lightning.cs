using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour, IEffect
{
    public void ApplyEffect(GameObject player)
    {
        const float damage = 1.0f;
        GameObject visualEffect = Resources.Load<GameObject>("Lightning");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = Array.FindAll(enemies, x => Vector3.Distance(player.transform.position, x.transform.position) < StatManager.getRange());
        foreach (GameObject enemy in enemies) { 
            GameObject currentVisual = Instantiate(visualEffect,enemy.transform.position,Quaternion.identity);
            currentVisual.GetComponent<FollowObject>().setObject(enemy);
            enemy.GetComponent<EnemyAbstract>().damageEnemy(damage* StatManager.getDamageMultiplyer());
            //Damage enemies
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        EffectManager.AddEffect(EffectManager.Effects.Lightning, 1, 1, this);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
