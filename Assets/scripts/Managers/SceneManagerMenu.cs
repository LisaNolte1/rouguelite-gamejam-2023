using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject saveButton;
    void Start()
    {
        saveButton = GameObject.FindGameObjectWithTag("saveButton");
        enableSave();
    }

    public static void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public static void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        enableSave();


    }

    private static void enableSave()
    {
        if(PlayerPrefs.GetFloat("coins", -1f) == -1f)
        {
            saveButton.SetActive(false);
        }
        else
        {
            saveButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
