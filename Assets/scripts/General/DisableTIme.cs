using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTIme : MonoBehaviour
{
    // Start is called before the first frame update
    const float timeConstant = 5f;
    private float timeCounter = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter > timeConstant)
        {
            timeCounter = 0f;
            this.gameObject.SetActive(false);
        }
    }
}
