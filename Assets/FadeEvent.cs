using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFade()
    {
        GameObject fade = Resources.Load<GameObject>("Fade");
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - 1.5f);
        GameObject fade1 = Instantiate(fade, pos, Quaternion.identity);
    }

}
