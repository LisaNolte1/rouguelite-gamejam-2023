using System;
using UnityEngine;

public class ForcePush : MonoBehaviour, IEffect
{
    public static float cooldown = 4f;
    public void ApplyEffect(GameObject player)
    {

        GameObject visualEffect = Resources.Load<GameObject>("ForcePush");
        Instantiate(visualEffect, player.transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
