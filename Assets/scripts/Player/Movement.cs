using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animControl;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //animControl = GetComponentInChildren<Animator>();
    }

    void movement(){
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0);
        input *= StatManager.getSpeed();
        input *= Time.deltaTime;
        this.transform.position += input;

        rb.velocity = Vector2.zero;

        

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            animControl.SetInteger("animState", 1);
        }
        else if(Input.GetAxisRaw("Vertical") == -1)
        {
            animControl.SetInteger("animState", -1);
        }
        else if(Input.GetAxisRaw("Horizontal") == 1)
        {
            animControl.SetInteger("animState", 3);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            animControl.SetInteger("animState", 2);
        }
        else
        {
            animControl.SetInteger("animState", 0);
        }


    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
}
