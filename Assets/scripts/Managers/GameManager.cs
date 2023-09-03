using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int kills = 0;
    public static int maxKills = 250;
    void Start()
    {
        kills = 0;
    }


    public static void addKill()
    {
        if(kills < maxKills)
        {
            kills++;
            if (kills % 10 == 0)
            {
                EventManager.chestSpawn();
                Debug.Log("Spawning chest");
            }
            Debug.Log("Kills: " + kills);
            UIManager.setKills(kills);
            if (kills == maxKills)
            {
                GameObject boss = Resources.Load<GameObject>("TreantBoss");
                GameObject spawnpoint = SpawnManager.spawn[0];
                GameObject bossSpawn = Instantiate(boss, spawnpoint.transform.position, Quaternion.identity);
            }
        }
        

    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
