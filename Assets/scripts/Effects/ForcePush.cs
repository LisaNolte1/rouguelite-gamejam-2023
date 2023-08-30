using System;
using UnityEngine;

public class ForcePush : MonoBehaviour, IEffect
{
    public static float cooldown = 4f;
    public void ApplyEffect(GameObject player)
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = Array.FindAll(enemies, x => Vector3.Distance(player.transform.position, x.transform.position) < StatManager.getRange() * 2);
        foreach (GameObject enemy in enemies)
        {

            Vector3 direction = player.transform.position - enemy.transform.position;
            direction = Vector3.Normalize(direction);
            float delta = Vector3.Distance(enemy.transform.position, player.transform.position);
            delta = StatManager.getRange() - delta;
            delta *= -1;
            enemy.transform.position += direction * delta;
            enemy.GetComponent<EnemyAbstract>().damageEnemy(StatManager.getDamageMultiplyer() * 3);


        }
        GameObject visualEffect = Resources.Load<GameObject>("ForcePush");
        Instantiate(visualEffect, player.transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
