using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animationControl;
    void Start()
    {
        animationControl = GetComponent<Animator>();
        Destroy(this.gameObject, animationControl.GetCurrentAnimatorStateInfo(0).length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
