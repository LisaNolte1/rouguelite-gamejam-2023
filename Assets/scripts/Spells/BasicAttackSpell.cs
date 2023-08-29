using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackSpell : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 Direction = Vector3.zero;
    bool targetFound = false;
    Vector3 startPos = Vector3.zero;
    void Start()
    {
        Debug.Log("Spawned");
        startPos = transform.position;
        SetDirection();
    }

    void SetDirection()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortageRange = 99999999999;
        GameObject currentSelection = null;
        foreach (GameObject enemy in enemies)
        {
            if(Vector3.Distance(enemy.transform.position, this.transform.position) < shortageRange)
            {
                currentSelection = enemy;
                shortageRange = Vector3.Distance(enemy.transform.position, this.transform.position);
            }
        }
        if (currentSelection != null)
        {
            targetFound = true;
        }
        else
        {
            return;
        }
        Direction = (this.transform.position - currentSelection.transform.position).normalized * -1;
    }

    void movement()
    {
        if (targetFound)
        {
            this.transform.position += (Direction * StatManager.getSpeed() * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void RangeCheck()
    {
        if (targetFound)
        {
            if(Vector3.Distance(startPos, this.transform.position) > StatManager.getRange() * 2)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(targetFound && collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyAbstract>().damageEnemy(StatManager.getDamageMultiplyer() * 2);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        RangeCheck();
    }
}
