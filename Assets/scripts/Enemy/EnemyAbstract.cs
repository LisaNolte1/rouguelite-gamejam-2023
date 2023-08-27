using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
    public abstract int Health { get; set; }

    public abstract float Damage { get; set; }

    public abstract int Armour { get; set; }

    public virtual void LowerHealth(float damageInflicted, int armour)
    {
        this.Health -= (int)(damageInflicted * (1 - 1 / armour));
    }

    public virtual void RaiseHealth(int healing)
    {
        this.Health += healing;
    }

    public abstract void InflictDamage(float damageInflicted);

    public abstract void Attack();
}
