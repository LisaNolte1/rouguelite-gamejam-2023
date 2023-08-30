using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class itemDrop : MonoBehaviour
{
    // Start is called before the first frame update
    IEffect effect = null;
    void Start()
    {

    }

    void randomDrop()
    {
        Array values = Enum.GetValues(typeof(EffectManager.Effects));
        int randomIndex = UnityEngine.Random.Range(0, 6);
        if (EffectManager.EffectList.ContainsKey((EffectManager.Effects)randomIndex))
        {
            randomDrop();
            return;
        }
        else
        {
            switch ((EffectManager.Effects)randomIndex)
            {
                case EffectManager.Effects.FireBall:
                    EffectManager.AddEffect(EffectManager.Effects.FireBall,0,5f,new FireBall());
                    break;
                case EffectManager.Effects.Lightning:
                    EffectManager.AddEffect(EffectManager.Effects.Lightning,0,10f, new Lightning());
                    break;
                case EffectManager.Effects.Repel:
                    EffectManager.AddEffect(EffectManager.Effects.Repel,0,10f,new Repel());
                    break;
                case EffectManager.Effects.Tornado:
                    EffectManager.AddEffect(EffectManager.Effects.Tornado,0,7f,new Tornado());
                    break;
                case EffectManager.Effects.Bolder:
                    EffectManager.AddEffect(EffectManager.Effects.Bolder, 0, 10f, new Bolder());
                    break;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            randomDrop();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
