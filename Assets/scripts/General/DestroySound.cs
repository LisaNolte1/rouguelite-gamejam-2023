using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroySound : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void check()
    {
        if (!source.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        check();
    }
}
