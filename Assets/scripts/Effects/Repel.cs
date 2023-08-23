using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repel : MonoBehaviour, IEffect
{
    // Start is called before the first frame update

    void Start()
    {
        EffectManager.AddEffect(EffectManager.Effects.Repel, 1, 1f, this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void IEffect.ApplyEffect(GameObject player)
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = Array.FindAll(enemies, x => Vector3.Distance(player.transform.position, x.transform.position) < StatManager.getRange());
        foreach (GameObject enemy in enemies) { 
            
                Vector3 direction = player.transform.position - enemy.transform.position;
                direction = Vector3.Normalize(direction);
                float delta = Vector3.Distance(enemy.transform.position, player.transform.position);
                delta = StatManager.getRange() - delta;
                delta *= -1;
                enemy.transform.position += direction * delta;
            
        }
    }
}
