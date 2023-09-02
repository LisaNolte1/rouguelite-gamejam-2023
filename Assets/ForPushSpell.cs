using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForPushSpell : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float damageMult = 2f;
    void Start()
    {
        
    }


    private void OnDestroy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        enemies = Array.FindAll(enemies, x => Vector3.Distance(player.transform.position, x.transform.position) < StatManager.getRange());
        foreach (GameObject enemy in enemies)
        {

            Vector3 direction = player.transform.position - enemy.transform.position;
            direction = Vector3.Normalize(direction);
            float delta = Vector3.Distance(enemy.transform.position, player.transform.position);
            delta = StatManager.getRange() - delta;
            delta *= -1;
            enemy.transform.position += direction * delta;
            enemy.GetComponent<EnemyAbstract>().damageEnemy(StatManager.getDamageMultiplyer() * damageMult);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
