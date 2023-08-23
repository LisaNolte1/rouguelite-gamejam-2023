using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject reference;
    void Start()
    {
        
    }

    public void setObject(GameObject Target)
    {
        reference = Target;
    }

    void movement()
    {
        if(reference != null && this.gameObject != null)
        {
            this.transform.position = reference.transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
}
