using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public float speed { get; set; } = 10F;
    public List<IProjectileEffect> effects = new List<IProjectileEffect>();
    public float Range = 50f;
    private Vector3 spawnPos = Vector3.zero;
    public Vector2 direction { get; set; } = Vector2.zero;

    public delegate void Movement();

    public Movement CurrentMovement;

    void Start()
    {

        CurrentMovement = movement;
        spawnPos = transform.position;
        foreach (var effect in effects)
        {
            effect.ApplyEffect(gameObject);
        }
    }


    void movement()
    {
        Vector3 delta = direction * speed * Time.deltaTime;
        this.transform.position += delta;
    }

    void despawnCheck()
    {
        if(Vector3.Distance(spawnPos, transform.position) > Range)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurrentMovement();
        despawnCheck();
    }
}
