using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    float length = 28f;
    float counter = 0f;
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter > length)
        {
            SceneManager.LoadScene(1);
        }
    }
}
