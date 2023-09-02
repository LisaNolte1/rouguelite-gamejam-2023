using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    static int kills = 0;
    public static int maxKills = 250;
    void Start()
    {
        kills = 0;
    }


    public static void addKill()
    {
        kills++;
        Debug.Log("Kills: " + kills);
        UIManager.setKills(kills);
        if(kills == maxKills)
        {
            //Spawn boss
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
