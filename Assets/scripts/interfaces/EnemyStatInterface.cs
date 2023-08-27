using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStatInterface
{
    public abstract int Health { get; set; }

    public abstract float Damage { get; set; }

    public abstract int Armour { get; set; }

    public abstract void LowerHealth(float damageInflicted);

    public abstract void RaiseHealth(int health, int healing);

    public abstract void InflictDamage(float damageInflicted);
}
