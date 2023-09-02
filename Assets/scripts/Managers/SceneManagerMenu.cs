using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject saveButton;
    public static GameObject howToPlayPanel;
    public static GameObject hideImage;
    void Start()
    {
        saveButton = GameObject.FindGameObjectWithTag("saveButton");
        howToPlayPanel = GameObject.FindGameObjectWithTag("howToPlay");
        hideImage = GameObject.FindGameObjectWithTag("hideImage");
        howToPlayPanel.SetActive(false);
        enableSave();
    }

    public static void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public static void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        enableSave();


    }

    public static void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
        hideImage.SetActive(false);
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
