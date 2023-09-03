using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        Instantiate(coin, GameObject.FindGameObjectWithTag("Player").transform.position + offset, Quaternion.identity);
 
    }

    public virtual void LowerHealth(float damageInflicted)
    {
        try
        {
            this.Health -= (int)(damageInflicted * (1 - 1 / Armour));
        }
        catch
        {
            this.Health -= (int)(damageInflicted);
        }
        Debug.Log(this.gameObject.name + " Health : " + this.Health);
        if(Health < 0)
        {
            gameObject.GetComponentInChildren<Animator>().SetBool("IsDead", true);
            DropCoin();
            GameManager.addKill();
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
