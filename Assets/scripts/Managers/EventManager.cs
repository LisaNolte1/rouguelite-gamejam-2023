using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawnTimer = 45f;
    private float spawnCounter = 0;
    void Start()
    {
        
    }

    void chestSpawn()
    {
        spawnCounter += Time.deltaTime;
        if(spawnCounter > spawnTimer )
        {
            if (GameObject.FindGameObjectsWithTag("Item").Length > 2)
                return;
            try
            {
                int random = SpawnManager.spawn.Count;
                random = Random.Range(0, random);
                Vector3 spawnPos = SpawnManager.spawn[random].transform.position;
                GameObject item = Resources.Load<GameObject>("Item");
                Instantiate(item, spawnPos, Quaternion.identity);
                //UIManager.toggleNotification("Chest spawned!", "Go Find it!");
                spawnCounter = 0;
            }
            catch
            {

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        chestSpawn();
    }
}