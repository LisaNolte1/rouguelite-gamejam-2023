using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static List<GameObject> spawn = new List<GameObject>();
    public float waveTimer = 5f;
    private float waveCounter = 0f;
    private float totalCount = 0f;
    public List<GameObject> enemies = new List<GameObject>();
    public int bossCount = 0;
    void Start()
    {
        waveCounter = waveTimer;
    }

    public static void RegisterSpawnPoint(GameObject spawnPoint)
    {
        spawn.Add(spawnPoint);
        Debug.Log("spawn Point registered");
    }

    void SpawnWave()
    {
        waveCounter += Time.deltaTime;
        totalCount++;
        if(waveCounter > waveTimer && GameObject.FindGameObjectsWithTag("Enemy").Length < 100)
        {
            waveCounter = 0f;
            foreach(GameObject spawnPoint in spawn)
            {
                try
                {
                    Instantiate(determineEnemySpawn(), spawnPoint.transform.position, Quaternion.identity);
                }
                catch(System.Exception e)
                {

                }
               
            }
            //spawn wave here
        }

    }

    GameObject determineEnemySpawn()
    {
        if(totalCount / 4 == 1)
        {
            //wave strength 2
            totalCount = 0;
            return enemies[1];
        }
        else if(GameManager.kills >= 250 && bossCount < 1)
        {
            this.bossCount++;
            return enemies[2];
        }
        else if(totalCount / 60 < 5)
        {
            //wave strength 1
            return enemies[0];
        }
        return enemies[0];
    }



    // Update is called once per frame
    void Update()
    {
        SpawnWave();
    }
}
