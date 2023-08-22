using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 10f;
    void Start()
    {
        
    }

    void movement(){
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        input *= speed;
        input *= Time.deltaTime;
        this.transform.position += input;
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
