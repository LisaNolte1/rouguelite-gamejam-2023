using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour, IEffect
{
    public void ApplyEffect(GameObject player)
    {
        GameObject visualEffect = Resources.Load<GameObject>("BasicAttack");
        GameObject currentVisual = Instantiate(visualEffect, player.transform.position, Quaternion.identity);
        
    }

    // Start is called before the first frame update
    void Start()
    {

        EffectManager.AddEffect(EffectManager.Effects.BasicAttack, 1, 5f, this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
