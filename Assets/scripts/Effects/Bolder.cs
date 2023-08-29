using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolder : MonoBehaviour, IEffect
{
    public void ApplyEffect(GameObject player)
    {
        GameObject visualEffect = Resources.Load<GameObject>("Bolder");
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> validEnemies = new List<GameObject>();
        foreach (GameObject enemy in Enemies)
        {
            if (Vector3.Distance(player.transform.position, enemy.transform.position) <= StatManager.getRange() * 3) ;
            {
                validEnemies.Add(enemy);
            }
        }

        int chosen = Random.Range(0, validEnemies.Count);

        GameObject currentVisual = Instantiate(visualEffect, validEnemies[chosen].transform.position, Quaternion.identity);
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
