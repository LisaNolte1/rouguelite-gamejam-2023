using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private float speed = 5.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void movement()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 velocity = input * speed;
        rb.velocity = velocity;

    }

    // Called when a collision occurs
    void OnCollisionEnter2D(Collision2D col)
    {
        // You can put collision handling code here if needed
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
}
