using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour, IEffect
{
    public void ApplyEffect(GameObject player)
    {
        GameObject fireBall = Resources.Load<GameObject>("fire_spell");
        for(int i = 0; i < 3; i++)
        {
            GameObject temp = Instantiate(fireBall, player.transform.position, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EffectManager.AddEffect(EffectManager.Effects.FireBall, 1, 1, this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
