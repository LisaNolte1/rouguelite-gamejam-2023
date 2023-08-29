using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
    public abstract int Health { get; set; }

    public abstract float Damage { get; set; }

    public abstract int Armour { get; set; }

    public abstract int CoinAmount { get; set; }

    public abstract int LootDropChance { get; set; }

    private  void DropCoin()
    {
        GameObject coin = Resources.Load<GameObject>("Coin");
        float maxOffset = 2;
        int counter = 0;
        Vector3 offset = new Vector3(
           Random.Range(-maxOffset, maxOffset),
           Random.Range(-maxOffset, maxOffset),
           0
       );

        transform.position += offset;
        if( coin != null )
        {
            Debug.Log("We got coins");
        }
        for (counter = 0; counter < CoinAmount; counter++)
        {
            Instantiate(coin, GameObject.FindGameObjectWithTag("Player").transform.position + offset, Quaternion.identity);
        }
    }

    public virtual void LowerHealth(float damageInflicted)
    {
        this.Health -= (int)(damageInflicted * (1 - 1 / Armour));
        if(Health < 0)
        {
            
            int chance = Random.Range(0, 101);
            if(this.LootDropChance > chance)
            {
                GameObject ItemDrop = Resources.Load<GameObject>("Item");
                Instantiate(ItemDrop, this.transform.position, Quaternion.identity);
            }
            DropCoin();
            Destroy(gameObject);
        }
    }

    public virtual void RaiseHealth(int healing)
    {
        this.Health += healing;
    }

    public abstract void damageEnemy(float damageInflicted);

    public abstract void Attack();

    
}
