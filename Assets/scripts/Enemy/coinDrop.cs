using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public int coinAmount = 1;
    float maxOffset = 2;
    void Start()
    {
        
    }

    private void OnDestroy()
    {

        GameObject coin = Resources.Load<GameObject>("coins");
        int counter = 0;
        Vector3 offset = new Vector3(
           Random.Range(-maxOffset, maxOffset),
           Random.Range(-maxOffset, maxOffset),
           0
       );

        transform.position += offset;
        for (counter = 0; counter < coinAmount; counter++)
        {
            Instantiate(coin, this.transform.position + offset, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
