using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolder : MonoBehaviour, IEffect
{
    public void ApplyEffect(GameObject player)
    {
        GameObject visualEffect = Resources.Load<GameObject>("Bolder");
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemies.Length == 0)
            return;
        foreach (GameObject enemy in Enemies)
        {
            if (Vector3.Distance(player.transform.position, enemy.transform.position) <= StatManager.getRange() * 3)
            {
                GameObject currentVisual = Instantiate(visualEffect, player.transform.position, Quaternion.identity);
                currentVisual.GetComponent<BolderSpell>().setTarget(enemy);
            }
        }

     
    }

    // Start is called before the first frame update

    void Start()
    {
        EffectManager.AddEffect(EffectManager.Effects.Bolder, 0, 1f, new Bolder());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
